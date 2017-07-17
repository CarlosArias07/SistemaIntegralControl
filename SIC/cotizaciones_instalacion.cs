namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cotizaciones_instalacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cotizaciones_instalacion()
        {
            cotizaciones_instalacion_articulos = new HashSet<cotizaciones_instalacion_articulos>();
            empleados_venta_instalacion = new HashSet<empleados_venta_instalacion>();
            servicios_instalacion = new HashSet<servicios_instalacion>();
        }

        [Key]
        public int id_CotIns { get; set; }

        public int? id_Emp { get; set; }

        public decimal? mtscable_CotIns { get; set; }

        public decimal? totalcable_CotIns { get; set; }

        [StringLength(100)]
        public string observaciones_CotIns { get; set; }

        [StringLength(1)]
        public string complejidad_CotIns { get; set; }

        public decimal? total_CotIns { get; set; }

        [StringLength(100)]
        public string nombrecli_CotIns { get; set; }

        public int? telefonocli_CotIns { get; set; }

        [StringLength(100)]
        public string domiciliocli_CotIns { get; set; }

        [StringLength(50)]
        public string correocli_CotIns { get; set; }

        public int? modificaciontec_CotIns { get; set; }

        public int? estatus_CotIns { get; set; }

        public virtual empleados empleados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotizaciones_instalacion_articulos> cotizaciones_instalacion_articulos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados_venta_instalacion> empleados_venta_instalacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<servicios_instalacion> servicios_instalacion { get; set; }
    }
}
