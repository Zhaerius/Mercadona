using Application.Core.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class MercaDbContectSeed
    {
        public static void Seed(MercaDbContext mercaDbContext)
        {
            // Ajout uniquement si table vide
            if(!mercaDbContext.Articles.Any())
            {
                var categories = GenerateCategories(5);
                var articles = GenerateArticles(50, categories);

                foreach (var article in articles)
                    mercaDbContext.Articles.Add(article);

                mercaDbContext.SaveChanges();
            }
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
