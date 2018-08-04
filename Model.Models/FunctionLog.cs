using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class FunctionLog
    {
        public int Id { get; set; }
        public string Program { get; set; }
        public string Discipline { get; set; }
        public DateTime LogDate { get; set; }
        public string Username { get; set; }
        public int? ProjectNumber { get; set; }
        public int DnaClientId { get; set; }
        public string Product { get; set; }
        public string OriginalAttribute { get; set; }
        public string ModifiedAttribute { get; set; }
        public string OriginalValue { get; set; }
        public string ModifiedValue { get; set; }
        public bool Success { get; set; }
        public string InputFiles { get; set; }
        public string OutputFiles { get; set; }
        public int? PrimaryDeviceCount { get; set; }
        public string Errors { get; set; }
    }
}
