using System;
using System.Linq;
using SocialCooking.Domain.Abstract;
using SocialCooking.Domain.Context;
using SocialCooking.Domain.Entity;

namespace SocialCooking.Domain.Concrete
{
    public class SCDishRepository : IDishRepository
    {
        private readonly SCContext _context = new SCContext();

        public IQueryable<DishIngredient> Ingredients => _context.Ingredients;
        public IQueryable<DishDifficultyLevel> DifficultyLevels => _context.DifficultyLevels;
        public IQueryable<DishCategory> Categories => _context.Categories;
        public IQueryable<Dish> Dishes => _context.Dishes;

        public Dish AddDishFromViewModel(Dish newDish)
        {
            newDish.AddDate = DateTime.Now;
            newDish.ModifyDate = DateTime.Now;
            newDish.PublishDate = DateTime.Now;
            newDish.Id = Guid.NewGuid();
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return newDish;
        }
    }
}
