namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class servicios_instalacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public servicios_instalacion()
        {
            empleados_asignados_instalacion = new HashSet<empleados_asignados_instalacion>();
        }

        [Key]
        public int id_SerIns { get; set; }

        public int id_CotIns { get; set; }

        [Column(TypeName = "date")]
        public DateTime? faceptacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? finicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ffinal { get; set; }

        [StringLength(1)]
        public string complejidad_CotIns { get; set; }

        public int? estatus_SerIns { get; set; }

        public virtual cotizaciones_instalacion cotizaciones_instalacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados_asignados_instalacion> empleados_asignados_instalacion { get; set; }
    }
}
