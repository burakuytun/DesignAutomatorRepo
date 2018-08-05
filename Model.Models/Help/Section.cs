using System.Collections.Generic;

namespace Model.Models.Help
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
