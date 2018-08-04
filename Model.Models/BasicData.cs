using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class BasicData
    {
        public decimal Sequence { get; set; }
        public string RequestDate { get; set; }
        public string Program { get; set; }
        public string Url { get; set; }
        public string ProjectPath { get; set; }
        public string FolderPath { get; set; }
        public string RelativeFolderPath { get; set; }
        public string FileName { get; set; }
        public string Xref { get; set; }
        public string ProjectNumber { get; set; }
        public decimal? SplistItemId { get; set; }
        public string SplistId { get; set; }
        public string WindowsIdentity { get; set; }
        public string Username { get; set; }
        public string Useremail { get; set; }
        public string Destination { get; set; }
        public string Reserved { get; set; }
        public string Status { get; set; }
        public bool? Deleted { get; set; }
    }
}
