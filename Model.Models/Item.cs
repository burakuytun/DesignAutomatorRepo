using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Active { get; set; }
        public string NavigateUrl { get; set; }
        public string Params { get; set; }
        public string EnabledExtensions { get; set; }
        public string FileCount { get; set; }
        public string Icon { get; set; }
        public int? MainId { get; set; }
        public short? Order { get; set; }
    }
}
