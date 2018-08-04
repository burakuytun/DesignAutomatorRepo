using System;

namespace Model.ViewModels
{
    public class UserDnaClientViewModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? DnaClientId { get; set; }
        public int? DnaAuthorizationLevelId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDefault { get; set; }

        //public DnaClientAuthorizationLevel DnaAuthorizationLevel { get; set; }
        public DnaClientViewModel DnaClient { get; set; }
        public UserViewModel User { get; set; }
    }
}
