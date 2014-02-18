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
    public  class Category
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Description")]
        [StringLength(50,MinimumLength=1)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Category Slug")]
        [RegularExpression(@"^[\S]*$", ErrorMessage = "White space found")]
        [StringLength(50, MinimumLength = 1)]
        public string Slug { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }

    public enum ControlsType
    {
        Text = 1,
        CheckBox =2,
        Select = 3,
        TextArea = 3,
        Image =4
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
        [Required]
        [Display(Name = "Sub Category Description")]
        [StringLength(50, MinimumLength = 1)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Sub category Slug")]
        [StringLength(50, MinimumLength = 1)]
        [RegularExpression(@"^[\S]*$", ErrorMessage = "White space found")]
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

        [Required]
        [Display(Name = "Field Order")]
        public int Order { get; set; }

        [Required]
        [Display(Name = "Field Description")]
        [StringLength(50, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Field Type")]
        public int Type { get; set; }

        [Required]
        [Display(Name = "Field Ennum Type")]
        public ControlsType ennType { get; set; }
        
        public dynamic Values { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }

    public class NodeItem {
        public NodeItem()
        {
            this.List = new List<NodeItem>();

        }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public string SlugTip { get; set; }
        public IList<NodeItem> List { get; private set; }
        public bool isChild { get {
            return this.List.Count() == 0;
        } }
    }

}