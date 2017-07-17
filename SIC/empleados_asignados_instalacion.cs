namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class empleados_asignados_instalacion
    {
        [Key]
        public int id_EmpAsiIns { get; set; }

        public int id_SerIns { get; set; }

        public int id_Emp { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fasignacion_EmpAsiIns { get; set; }

        public virtual empleados empleados { get; set; }

        public virtual servicios_instalacion servicios_instalacion { get; set; }
    }
}
