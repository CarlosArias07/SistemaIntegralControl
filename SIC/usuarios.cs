namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Emp { get; set; }

        [Required]
        [StringLength(25)]
        public string contraseña_Usu { get; set; }

        public int tipo_Usu { get; set; }

        public virtual empleados empleados { get; set; }
    }
}
