namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class niveles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public niveles()
        {
            empleados_venta_instalacion = new HashSet<empleados_venta_instalacion>();
            niveles_empleados = new HashSet<niveles_empleados>();
        }

        [Key]
        public int id_Niv { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion_Niv { get; set; }

        public decimal pcomision_Niv { get; set; }

        public decimal? venta_Niv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados_venta_instalacion> empleados_venta_instalacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<niveles_empleados> niveles_empleados { get; set; }
    }
}
