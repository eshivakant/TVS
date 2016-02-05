namespace TVS.WebApp.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RatingBreakdown")]
    public partial class RatingBreakdown
    {
        public long Id { get; set; }

        public long PersonRatingId { get; set; }

        public long RoleParameterId { get; set; }

        public int Score { get; set; }

        public virtual PersonRating PersonRating { get; set; }

        public virtual RoleParameter RoleParameter { get; set; }
    }
}
