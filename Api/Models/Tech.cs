using System;
using System.Collections.Generic;

#nullable disable

namespace PeopleManagement.Models
{
    public partial class Tech
    {
        public int? Id { get; set; }
        public string TechName { get; set; }
        public int? Years { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
