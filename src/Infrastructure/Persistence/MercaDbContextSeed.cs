using Application.Core.Entities;
using Bogus;
using Infrastructure.Identity.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;

namespace Infrastructure.Persistence
{
    public class MercaDbContextSeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var mercaDbContext = serviceProvider.GetRequiredService<MercaDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService< RoleManager<IdentityRole>>();
            var usersOptions = serviceProvider.GetRequiredService<IOptions<List<IdentityUserOptions>>>().Value;

            // Ajout uniquement si table vide
            if (!mercaDbContext.Articles.Any())
            {
                //Génération des entitées
                var promotions = GeneratePromotions();
                var categories = GenerateCategories(5);
                var articles = GenerateArticles(50, categories);

                // Ajout Promotions
                foreach (var promotion in promotions)
                    mercaDbContext.Promotions.Add(promotion);

                // Ajout Article, Catégories et relation promo en fonction de l'index
                for (int i = 0; i < articles.Count; i++)
                {
                    if ((i % 2) == 0)
                    {
                        articles[i].Promotions = new List<PromotionEntity>()
                        {
                            promotions[GetRandomNumber(promotions.Count)]
                        };
                    }

                    mercaDbContext.Articles.Add(articles[i]);
                }

                // Ajout AdminUser et Roles
                foreach (var userOptions in usersOptions)
                {
                    var user = await GenerateDefaultUser(userManager, userOptions);
                    await GenerateDefaultRoles(roleManager, userOptions);
                    await userManager.AddToRolesAsync(user, userOptions.Roles);
                }

                // Sauvegarde BDD
                await mercaDbContext.SaveChangesAsync();
            }
        }

        //Fake Role
        private async static Task GenerateDefaultRoles(RoleManager<IdentityRole> roleManager, IdentityUserOptions userOptions)
        {
            foreach (var role in userOptions.Roles)
            {
                var roleExist = await roleManager.FindByNameAsync(role);

                if (roleExist == null)
                {
                    var defaultRole = new IdentityRole(role);
                    await roleManager.CreateAsync(defaultRole);
                }
            }
        }

        //Fake User
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
        private static IList<ArticleEntity> GenerateArticles(int count, IEnumerable<CategoryEntity> categories)
        {
            var faker = new Faker<ArticleEntity>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Commerce.ProductName())
                .RuleFor(a => a.Description, f => f.Commerce.ProductDescription())
                .RuleFor(a => a.BasePrice, f => decimal.Parse(f.Commerce.Price(1, 50)))
                .RuleFor(a => a.Image, f => f.Image.PicsumUrl())
                .RuleFor(a => a.Category, f => f.PickRandom(categories));
                //.RuleFor(a => a.Promotions, f => f.PickRandom(promotions, f.Random.Number(0, 2)).ToList());

            return faker.Generate(count);
        }

        //Fake Catégorie
        private static IEnumerable<CategoryEntity> GenerateCategories(int count)
        {
            var faker = new Faker<CategoryEntity>()
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);

            return faker.Generate(count);
        }

        //Fake Promotions
        private static IList<PromotionEntity> GeneratePromotions()
        {
            var promotions = new List<PromotionEntity>();

            var discountList = new List<int>(){ 5, 10, 15, 20 };

            foreach (var discount in discountList)
            {
                var promotion = new PromotionEntity()
                {
                    Name = $"Super Promo {discount} %",
                    Discount = discount,
                    Start = DateOnly.FromDateTime(DateTime.Now),
                    End = DateOnly.FromDateTime(DateTime.Now.AddYears(1))
                };

                promotions.Add(promotion);
            }

            return promotions;
        }

        private static int GetRandomNumber(int max)
        {
            var random = new Random();
            return random.Next(0, max);
        }
    }
}
