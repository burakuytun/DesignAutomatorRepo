using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ErrorCheckMapping
    {
        public int ErrorCheckId { get; set; }
        public string ErrorType { get; set; }
        public string SpName { get; set; }
        public string SpColumnName { get; set; }
        public string ErrorDrawingPathwithname { get; set; }
        public int ErrorInsertPriority { get; set; }
        public string Description { get; set; }
        public string ErrorImagePathwithname { get; set; }
    }
}
