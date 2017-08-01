namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class servicios_info
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_CotIns { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_CotIns { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_EmpV { get; set; }

        public byte[] img_EmpV { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string nombre_EmpV { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string apaterno_EmpV { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string nombre_Pro { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Art { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1)]
        public string tipo_Pro { get; set; }

        [StringLength(50)]
        public string nombre_Art { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte[] imagen_Pro { get; set; }

        public decimal? mtscable_CotIns { get; set; }

        public decimal? totalcable_CotIns { get; set; }

        [StringLength(100)]
        public string observaciones_CotIns { get; set; }

        public decimal? total_CotIns { get; set; }

        [StringLength(100)]
        public string nombrecli_CotIns { get; set; }

        public int? telefonocli_CotIns { get; set; }

        [StringLength(100)]
        public string domiciliocli_CotIns { get; set; }

        [StringLength(50)]
        public string correocli_CotIns { get; set; }

        [StringLength(1)]
        public string complejidad_CotIns { get; set; }

        public int? estatus_CotIns { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_SerIns { get; set; }

        [Column(TypeName = "date")]
        public DateTime? faceptacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? finicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ffinal { get; set; }

        public int? estatus_SerIns { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fasignacion_EmpAsiIns { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_EmpT { get; set; }

        public byte[] img_EmpT { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string nombre_EmpT { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string apaterno_EmpT { get; set; }
    }
}
