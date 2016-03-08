using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialCooking.Domain.Entity;

namespace SocialCooking.Domain.Context
{
    public class SCContext: DbContext
    {
        public DbSet<DishIngredient> Ingredients { get; set; }
        public DbSet<DishDifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<DishCategory> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}
