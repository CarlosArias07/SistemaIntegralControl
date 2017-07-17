namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class articulos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public articulos()
        {
            cotizaciones_instalacion_articulos = new HashSet<cotizaciones_instalacion_articulos>();
        }

        [Key]
        public int id_Art { get; set; }

        public int id_Pro { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo_Pro { get; set; }

        [StringLength(50)]
        public string nombre_Pro { get; set; }

        [StringLength(100)]
        public string descripcion_Pro { get; set; }

        [Required]
        public byte[] imagen_Pro { get; set; }

        public decimal? precio_Pro { get; set; }

        public int? estatus_Pro { get; set; }

        public virtual proveedores proveedores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotizaciones_instalacion_articulos> cotizaciones_instalacion_articulos { get; set; }
    }
}
