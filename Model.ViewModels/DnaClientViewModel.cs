using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class DnaClientViewModel
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string Uname { get; set; }
        public string Dnalogo { get; set; }
        public string Colour1 { get; set; }
        public string Colour2 { get; set; }
        public string Naming { get; set; }
        public string Colour3 { get; set; }
        public string Colour4 { get; set; }
        public string Colour5 { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }
        public string ClientCountry { get; set; }
        public string ClientPostCode { get; set; }
    }
}
