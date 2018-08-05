﻿using System.Collections.Generic;

namespace Model.ViewModels.Help
{
    public class SectionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
