namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class niveles_empleados
    {
        [Key]
        public int id_NivEmp { get; set; }

        public int id_Emp { get; set; }

        public int id_Niv { get; set; }

        public virtual empleados empleados { get; set; }

        public virtual niveles niveles { get; set; }
    }
}
