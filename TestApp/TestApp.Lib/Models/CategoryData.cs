using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Lib.Models
{
    public class ChildrenData
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string name { get; set; }
        public bool is_active { get; set; }
        public int position { get; set; }
        public int level { get; set; }
        public int product_count { get; set; }
        public List<ChildrenData> children_data { get; set; }
        public List<Item> products { get; set; }
        public ChildrenData()
        {
            products = new List<Item>();
        }
    }

    public class ProductCategory
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string name { get; set; }
        public bool is_active { get; set; }
        public int position { get; set; }
        public int level { get; set; }
        public int product_count { get; set; }
        public List<ChildrenData> children_data { get; set; }
        public List<Item> products { get; set; }

        public ProductCategory()
        {
            products = new List<Item>();
        }
    }
}
