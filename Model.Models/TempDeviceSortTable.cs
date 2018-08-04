using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class TempDeviceSortTable
    {
        public int Id { get; set; }
        public string DoorName { get; set; }
        public string DeviceName { get; set; }
        public string Type { get; set; }
        public string NickName { get; set; }
        public string Priority { get; set; }
        public string SubPri { get; set; }
        public string TypeNm { get; set; }
        public int? Secure { get; set; }
        public string LongDoorName { get; set; }
        public int? SequenceNum { get; set; }
    }
}
