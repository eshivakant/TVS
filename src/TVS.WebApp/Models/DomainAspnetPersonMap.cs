namespace TVS.WebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DomainAspnetPersonMap")]
    public partial class DomainAspnetPersonMap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long DomainId { get; set; }

        [Required]
        [StringLength(450)]
        public string AspnetId { get; set; }

        public virtual Person Person { get; set; }
    }
}
