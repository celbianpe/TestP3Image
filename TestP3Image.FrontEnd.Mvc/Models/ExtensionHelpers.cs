﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestP3Image.FrontEnd.Mvc.Models
{
    public static  partial  class ExtensionHelpers
    {
        public static IList<NodeItem> toNodeList(this IEnumerable<Category> entry)
        {
            IList<NodeItem> elements = new List<NodeItem>();
            foreach (var item in entry)
            {
                var nodeCategory = new NodeItem { Id = item.Id, Description =  item.Description,SlugTip = item.Slug, Type = "Categories" };

                if (item.SubCategories != null) { 
                    foreach (var SubItem in item.SubCategories.OrderByDescending(t=> t.Id))
                    {
                        var nodeSubCategory = new NodeItem { Id = SubItem.Id, Description =  SubItem.Description ,SlugTip= SubItem.slug, Type = "SubCategories" };

                        if (SubItem.Fields != null)
                        {
                            foreach (var field in SubItem.Fields.OrderByDescending(t=> t.Order))
                            {
                                var nodeField = new NodeItem { Id = field.Id, Description =  field.Description, SlugTip= "", Type = field.ennType.ToString() };

                                nodeField.List.Add(nodeField);
                            }
                        }
                        nodeCategory.List.Add(nodeSubCategory);
                    }
                }
                elements.Add(nodeCategory);
            }

            return elements;
        }


     
    }
}