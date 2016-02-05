namespace TVS.WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            AddressOccupations = new HashSet<AddressOccupation>();
            AddressOwnerships = new HashSet<AddressOwnership>();
            DomainAspnetPersonMaps = new HashSet<DomainAspnetPersonMap>();
            PersonAttributes = new HashSet<PersonAttribute>();
            PersonRatings = new HashSet<PersonRating>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Initial { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(250)]
        public string PlaceOfBirth { get; set; }

        [StringLength(50)]
        public string AdhaarCard { get; set; }

        [StringLength(50)]
        public string PAN { get; set; }

        [StringLength(250)]
        public string IdentificationMark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressOccupation> AddressOccupations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressOwnership> AddressOwnerships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DomainAspnetPersonMap> DomainAspnetPersonMaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonAttribute> PersonAttributes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonRating> PersonRatings { get; set; }
    }
}
