using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestP3Image.FrontEnd.Mvc.Models
{
    public partial class FormsBuilderModel : DbContext
    {

        public FormsBuilderModel() : base("FormsBuilderConnection")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Field> Fields { get; set; }
    }

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }

    [Table("SubCategory")]
    public partial class SubCategory
    {
        public SubCategory()
        {
            this.Fields = new HashSet<Field>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string slug { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
    }

    [Table("Field")]
    public partial class Field
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Values { get; set; }
        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}