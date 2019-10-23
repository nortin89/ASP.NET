namespace WorkOrders.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Parts = new HashSet<Part>();
        }

        public int? OrderId { get; set; }

        public int? OrderNumber { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RepairDate { get; set; }

        [StringLength(50)]
        public string TechName { get; set; }

        [StringLength(10)]
        public string LicencePlate { get; set; }

        [StringLength(10)]
        public string VehicleYear { get; set; }

        [StringLength(50)]
        public string VehicleMake { get; set; }

        [StringLength(50)]
        public string VehicleModel { get; set; }

        [StringLength(50)]
        public string Mileage { get; set; }

        public bool? Lube { get; set; }

        public bool? OilChange { get; set; }

        public bool? FlushTransmission { get; set; }

        public bool? FlushDifferential { get; set; }

        public bool? Wash { get; set; }

        public bool? Polish { get; set; }

        public int? LaborHours { get; set; }

        public decimal? LaborCostPerHour { get; set; }

        public decimal? TotalCostParts { get; set; }

        public decimal? TotalCostLabor { get; set; }

        public decimal? TotalCostLaborParts { get; set; }

        public decimal? TotalTax { get; set; }

        public decimal? GrandTotal { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Part> Parts { get; set; }
    }
}
