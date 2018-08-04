using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class TemplateParameter
    {
        public string SystemType { get; set; }
        public string PanelType { get; set; }
        public string ReaderType { get; set; }
        public string ParameterType { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ValueComment { get; set; }
        public int Id { get; set; }
    }
}
