namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleados()
        {
            cotizaciones_instalacion = new HashSet<cotizaciones_instalacion>();
            empleados_asignados_instalacion = new HashSet<empleados_asignados_instalacion>();
            empleados_venta_instalacion = new HashSet<empleados_venta_instalacion>();
            niveles = new HashSet<niveles>();
        }

        [Key]
        public int id_Emp { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_Emp { get; set; }

        [Required]
        [StringLength(50)]
        public string apaterno_Emp { get; set; }

        [StringLength(50)]
        public string amaterno_Emp { get; set; }

        [StringLength(1)]
        public string sexo_Emp { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo_Emp { get; set; }

        public int? edad_Emp { get; set; }

        public int? telefono_Emp { get; set; }

        [StringLength(50)]
        public string calle_Emp { get; set; }

        [StringLength(50)]
        public string colonia_Emp { get; set; }

        public int? numero_Emp { get; set; }

        [StringLength(50)]
        public string correo_Emp { get; set; }

        [StringLength(20)]
        public string estadoc_Emp { get; set; }

        [StringLength(50)]
        public string conquienvive_Emp { get; set; }

        [StringLength(50)]
        public string familia_Emp { get; set; }

        [StringLength(100)]
        public string explaboral_Emp { get; set; }

        [StringLength(50)]
        public string especialidad_Emp { get; set; }

        public int? estatus_Emp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotizaciones_instalacion> cotizaciones_instalacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados_asignados_instalacion> empleados_asignados_instalacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados_venta_instalacion> empleados_venta_instalacion { get; set; }

        public virtual usuarios usuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<niveles> niveles { get; set; }
    }
}
