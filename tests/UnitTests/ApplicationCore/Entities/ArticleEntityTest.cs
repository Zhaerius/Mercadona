using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core.Entities;

namespace UnitTests.ApplicationCore.Entities
{
    [TestClass]
    public class ArticleEntityTest
    {
        private ArticleEntity _article;
        private PromotionEntity _validPromotion;
        private PromotionEntity _validPromotionMax;
        private PromotionEntity _invalidPromotion;

        [TestInitialize]
        public void Setup()
        {
            _article = new ArticleEntity()
            {
                Name = "string",
                Description = "string",
                Image = "string",
                BasePrice = 10
            };

            _validPromotion = new PromotionEntity()
            {
                Name = "string",
                Discount = 10,
                Start = DateOnly.FromDateTime(DateTime.Now),
                End = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)),                
            };

            _validPromotionMax = new PromotionEntity()
            {
                Name = "string",
                Discount = 80,
                Start = DateOnly.FromDateTime(DateTime.Now),
                End = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)),
            };

            _invalidPromotion = new PromotionEntity()
            {
                Name = "string",
                Discount = 10,
                Start = DateOnly.FromDateTime(DateTime.Now.AddMonths(-2)),
                End = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1))
            };
        }

        [TestMethod]
        public void CurrentPromotion_WithNoPromotions_ShouldBe_Null() 
        {
            //Arrange 
            var article = _article;
            article.Promotions = null;

            //Act

            //Assertion
            Assert.IsNull(article.CurrentPromotion);
        }

        [TestMethod]
        public void CurrentPromotion_WithNoPromotion_DiscountPrice_EgalTo_BasePrice()
        {
            var article = _article;
            article.Promotions = null;

            Assert.AreEqual(article.BasePrice, article.DiscountPrice);
        }

        [TestMethod]
        public void CurrentPromotion_WithNoPromotion_OnDiscount_ShouldBe_False()
        {
            var article = _article;
            article.Promotions = null;

            Assert.IsFalse(article.OnDiscount);
        }

        [TestMethod]
        public void CurrentPromotion_WithInactivePromotions_ShouldBe_Null()
        {
            var article = _article;
            article.Promotions = new List<PromotionEntity>() { _invalidPromotion };

            Assert.IsNull(article.CurrentPromotion);
        }

        [TestMethod]
        public void CurrentPromotion_WithInactivePromotions_DiscountPrice_EgalTo_BasePrice()
        {
            var article = _article;
            article.Promotions = new List<PromotionEntity>() { _invalidPromotion };

            Assert.AreEqual(article.BasePrice, article.DiscountPrice);
        }

        [TestMethod]
        public void CurrentPromotion_WithInactivePromotions_OnDiscount_ShouldBe_False()
        {
            var article = _article;
            article.Promotions = new List<PromotionEntity>() { _invalidPromotion };

            Assert.IsFalse(article.OnDiscount);
        }

        [TestMethod]
        public void CurrentPromotion_WithActivePromotions_ShouldBe_NotNull()
        {
            var article = _article;
            article.Promotions = new List<PromotionEntity>() { _invalidPromotion, _validPromotion };

            Assert.IsNotNull(article.CurrentPromotion);
        }

        [TestMethod]
        public void CurrentPromotion_WithActivePromotions_OnDiscount_ShouldBe_True()
        {
            var article = _article;
            article.Promotions = new List<PromotionEntity>() { _invalidPromotion, _validPromotion };

            Assert.IsTrue(article.OnDiscount);
        }

        [TestMethod]
        public void CurrentPromotion_WithActivePromotions_Discount_ShoulBe_Egal_80()
        {
            var article = _article;
            article.Promotions = new List<PromotionEntity>() { _invalidPromotion, _validPromotion, _validPromotionMax };

            Assert.AreEqual(article.CurrentPromotion!.Discount, 80);
        }

        [TestMethod]
        public void CurrentPromotion_WithActivePromotions_DiscountPrice_ShoulBe_Egal_2()
        {
            var article = _article;
            article.Promotions = new List<PromotionEntity>() { _invalidPromotion, _validPromotion, _validPromotionMax };

            Assert.AreEqual(article.DiscountPrice, 2);
        }

    }
}
