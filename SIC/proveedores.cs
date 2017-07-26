namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proveedores()
        {
            articulos = new HashSet<articulos>();
        }

        [Key]
        public int id_Pro { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string nombre_Pro { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string giro_Pro { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string direccion_Pro { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string pagweb_Pro { get; set; }

        public int? estatus_Pro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<articulos> articulos { get; set; }
    }
}
