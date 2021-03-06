namespace DAL.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            EventsOrganizers = new HashSet<EventsOrganizers>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Site { get; set; }

        [Column(TypeName = "image")]
        public byte[] Poster { get; set; }

        public bool IsNew { get; set; }

        public int TypeId { get; set; }

        public int CategoryId { get; set; }

        public int AgeId { get; set; }

        public virtual Ages Ages { get; set; }

        public virtual Category Category { get; set; }

        public virtual Type Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventsOrganizers> EventsOrganizers { get; set; }
    }
}
