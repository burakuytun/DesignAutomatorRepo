using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Type
    {
        public Type()
        {
            Devices = new HashSet<Device>();
            ProductLibrary = new HashSet<ProductLibrary>();
            TypeDisciplineMap = new HashSet<TypeDisciplineMap>();
            TypeTagMap = new HashSet<TypeTagMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseTypeId { get; set; }
        public bool? IsVisible { get; set; }

        public virtual BaseType BaseType { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<ProductLibrary> ProductLibrary { get; set; }
        public virtual ICollection<TypeDisciplineMap> TypeDisciplineMap { get; set; }
        public virtual ICollection<TypeTagMap> TypeTagMap { get; set; }
    }
}
