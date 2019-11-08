namespace WorkOrders.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
            Parts = new HashSet<Part>();
        }

        public int? CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }


        [StringLength(50)]
        public string StreetAddress { get; set; }


        [StringLength(50)]
        public string City { get; set; }


        [StringLength(30)]
        public string State { get; set; }


        [StringLength(10)]
        public string Zip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Part> Parts { get; set; }
    }
}
