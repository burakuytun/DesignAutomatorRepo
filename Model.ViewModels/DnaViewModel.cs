namespace Model.ViewModels
{
    public class DnaViewModel
    {
        public int Id { get; set; }
        public int? TypeTagId { get; set; }
        public int? DnaclientId { get; set; }
        public string Value { get; set; }

        //public Dnaclient Dnaclient { get; set; }
        //public TypeTagMap TypeTag { get; set; }
    }
}
