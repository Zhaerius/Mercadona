using Application.Core.Entities;
using Bogus;
using Infrastructure.Identity.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence
{
    public class MercaDbContextSeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var mercaDbContext = serviceProvider.GetRequiredService<MercaDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService< RoleManager<IdentityRole>>();
            var userOptions = serviceProvider.GetRequiredService<IOptions<IdentityUserOptions>>().Value;

            // Ajout uniquement si table vide
            if (!mercaDbContext.Articles.Any())
            {
                // Ajout Article et Catégories
                var categories = GenerateCategories(5);
                var articles = GenerateArticles(50, categories);
                foreach (var article in articles)
                    mercaDbContext.Articles.Add(article);

                // Ajout AdminUser et Roles
                var user = await GenerateDefaultUser(userManager, userOptions);
                await GenerateDefaultRoles(roleManager, userOptions);
                await userManager.AddToRolesAsync(user, userOptions.Roles);

                await mercaDbContext.SaveChangesAsync();
            }
        }


        private async static Task GenerateDefaultRoles(RoleManager<IdentityRole> roleManager, IdentityUserOptions userOptions)
        {
            foreach (var role in userOptions.Roles)
            {
                var defaultRole = new IdentityRole(role);
                await roleManager.CreateAsync(defaultRole);
            }
        }

        private async static Task<IdentityUser> GenerateDefaultUser(UserManager<IdentityUser> userManager, IdentityUserOptions userOptions)
        {
            var defaultUser = new IdentityUser()
            {
                UserName = userOptions.UserName,
                Email = userOptions.UserName,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(defaultUser, userOptions.Password);

            return defaultUser;
        }

        //Fake Article
        private static IEnumerable<ArticleEntity> GenerateArticles(int count, IEnumerable<CategoryEntity> categories)
        {
            var faker = new Faker<ArticleEntity>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Commerce.ProductName())
                .RuleFor(a => a.Description, f => f.Commerce.ProductDescription())
                .RuleFor(a => a.BasePrice, f => double.Parse(f.Commerce.Price(1, 50)))
                .RuleFor(a => a.Image, f => f.Image.PicsumUrl())
                .RuleFor(a => a.Category, f => f.PickRandom(categories));
                //.RuleFor(a => a.Categories, f => f.PickRandom(categories, f.Random.Number(1, 2)).ToList());

            return faker.Generate(count);
        }

        //Fake Catégorie
        private static IEnumerable<CategoryEntity> GenerateCategories(int count)
        {
            var faker = new Faker<CategoryEntity>()
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);

            return faker.Generate(count);
        }
    }
}
