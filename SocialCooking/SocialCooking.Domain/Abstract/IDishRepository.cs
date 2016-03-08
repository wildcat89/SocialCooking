using System.Linq;
using SocialCooking.Domain.Entity;

namespace SocialCooking.Domain.Abstract
{
    public interface IDishRepository
    {
        IQueryable<DishIngredient> Ingredients { get; }
        IQueryable<DishDifficultyLevel> DifficultyLevels { get; }
        IQueryable<DishCategory> Categories { get; }
        IQueryable<Dish> Dishes { get; }

        Dish AddDishFromViewModel(Dish newDish);
    }
}
