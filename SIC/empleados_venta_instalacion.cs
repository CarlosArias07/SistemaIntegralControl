namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class empleados_venta_instalacion
    {
        [Key]
        public int id_EmpVenIns { get; set; }

        public int id_Emp { get; set; }

        public int id_CotIns { get; set; }

        public int id_Niv { get; set; }

        public decimal? totalventa_EmpVenIns { get; set; }

        [Column(TypeName = "date")]
        public DateTime? faceptacion_EmpVenIns { get; set; }

        public int? considerada_EmpVenIns { get; set; }

        public virtual cotizaciones_instalacion cotizaciones_instalacion { get; set; }

        public virtual empleados empleados { get; set; }

        public virtual niveles niveles { get; set; }
    }
}
