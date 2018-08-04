using System;

namespace Model.Models
{
    public partial class UserDnaClient
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? DnaClientId { get; set; }
        public int? DnaAuthorizationLevelId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDefault { get; set; }

        public virtual DnaClientAuthorizationLevel DnaAuthorizationLevel { get; set; }
        public virtual DnaClient DnaClient { get; set; }
        public virtual User User { get; set; }
    }
}
