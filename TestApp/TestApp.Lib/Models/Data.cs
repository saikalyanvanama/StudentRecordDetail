using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Test///////

namespace TestApp.Lib.Models
{
    public class CustomAttribute
    {
        public string attribute_code { get; set; }
        public object value { get; set; }
        
    }

    public class CustomAttribute2
    {
        public string attribute_code { get; set; }
        public object value { get; set; }
    }

    public class Child
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public int attribute_set_id { get; set; }
        public int price { get; set; }
        public int status { get; set; }
        public int visibility { get; set; }
        public string type_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public double weight { get; set; }
        public List<object> product_links { get; set; }
        public List<object> tier_prices { get; set; }
        public List<CustomAttribute2> custom_attributes { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public int attribute_set_id { get; set; }
        public int price { get; set; }
        public int status { get; set; }
        public int visibility { get; set; }
        public string type_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public double weight { get; set; }
        public List<object> product_links { get; set; }
        public List<object> tier_prices { get; set; }
        public List<CustomAttribute> custom_attributes { get; set; }
        public int? minPrice { get; set; }
        public int? maxPrice { get; set; }
        public List<Child> children { get; set; }
    }

    public class Filter
    {
        public string field { get; set; }
        public string value { get; set; }


        public string condition_type { get; set; }
    }

    public class FilterGroup
    {
        public List<Filter> filters { get; set; }
    }

    public class SortOrder
    {
        public string field { get; set; }
        public string direction { get; set; }
    }

    public class SearchCriteria
    {
        public List<FilterGroup> filter_groups { get; set; }
        public List<SortOrder> sort_orders { get; set; }
        public int page_size { get; set; }
        public int current_page { get; set; }
    }

    public class ProductResult
    {
        public List<Item> items { get; set; }

        public SearchCriteria search_criteria { get; set; }
        public int total_count { get; set; }
        public string timeStamp { get; set; }
    }
}
