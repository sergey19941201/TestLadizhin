//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dishes
    {
        [Key]
        public int Dish_Id { get; set; }
        public string DishName { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public Nullable<int> Receipt_Id { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual Receipts Receipts { get; set; }
    }
}
