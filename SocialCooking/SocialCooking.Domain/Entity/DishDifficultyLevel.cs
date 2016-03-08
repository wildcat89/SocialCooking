using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialCooking.Domain.Entity
{
    [Table("DishDifficultyLevels")]
    public class DishDifficultyLevel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int DifficultyLevel { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
