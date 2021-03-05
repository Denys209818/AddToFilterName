using System;
using System.Collections.Generic;
using System.Text;

namespace AddElementToFilterName.Models
{
    public class FilterNameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCollapsed { get; set; } = true;
        public ICollection<FilterValueModel> Children { get; set; }
    }
}
