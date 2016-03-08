using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialCooking.Domain.Entity
{
    [Table("DishCategories")]
    public class DishCategory
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
