using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestP3Image.FrontEnd.Mvc.Models
{
    public static  partial  class ExtensionHelpers
    {
        public static IList<NodeItem> toNodeList<T>(this IEnumerable<T> entry) where  T : class 
        {
            IList<NodeItem> elements = new List<NodeItem>();

            if(entry.ToList().GetType() == typeof(List<Category>)){
                List<Category> foritem = entry.Cast<Category>().ToList();

                foreach (Category item in foritem.OrderByDescending(t => t.Id))
                {
                    var nodeCategory = new NodeItem { Id = item.Id, Description = item.Description, SlugTip = item.Slug, Type = "Categories" };

                    if (item.SubCategories != null)
                    {
                        foreach (var SubItem in item.SubCategories.OrderByDescending(t => t.Id))
                        {
                            var nodeSubCategory = new NodeItem { Id = SubItem.Id, Description = SubItem.Description, SlugTip = SubItem.slug, Type = "SubCategories" };

                            if (SubItem.Fields != null)
                            {
                                foreach (var field in SubItem.Fields.OrderByDescending(t => t.Order))
                                {
                                    var nodeField = new NodeItem { Id = field.Id, Description = field.Description, SlugTip = "", Type = field.ennType.ToString() };

                                    nodeField.List.Add(nodeField);
                                }
                            }
                            nodeCategory.List.Add(nodeSubCategory);
                        }
                    }
                    elements.Add(nodeCategory);
                }
            }
            else if (entry.ToList().GetType() == typeof(List<SubCategory>))
            {
                List<SubCategory> foritem = entry.Cast<SubCategory>().ToList();
                foreach (var SubItem in foritem.OrderByDescending(t => t.Id))
                {
                    var nodeSubCategory = new NodeItem { Id = SubItem.Id, Description = SubItem.Description, SlugTip = SubItem.slug, Type = "SubCategories" };

                    if (SubItem.Fields != null)
                    {
                        foreach (var field in SubItem.Fields.OrderByDescending(t => t.Order))
                        {
                            var nodeField = new NodeItem { Id = field.Id, Description = field.Description, SlugTip = "", Type = field.ennType.ToString() };

                            nodeField.List.Add(nodeField);
                        }
                    }
                    elements.Add(nodeSubCategory);
                }

            }
            else
            {
                List<Field> foritem = entry.Cast<Field>().ToList();
                foreach (var field in  entry.OfType<Field>().OrderByDescending(t => t.Order))
                {
                    var nodeField = new NodeItem { Id = field.Id, Description = field.Description, SlugTip = "", Type = field.ennType.ToString() };

                    elements.Add(nodeField);
                }
            }
            

            return elements;
        }


     
    }
}