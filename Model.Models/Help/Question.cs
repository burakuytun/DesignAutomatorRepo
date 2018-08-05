namespace Model.Models.Help
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
