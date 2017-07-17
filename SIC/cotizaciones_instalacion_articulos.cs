namespace SIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cotizaciones_instalacion_articulos
    {
        [Key]
        public int id_CotIA { get; set; }

        public int id_CotIns { get; set; }

        public int id_Art { get; set; }

        public decimal? precioactual_Art { get; set; }

        public virtual articulos articulos { get; set; }

        public virtual cotizaciones_instalacion cotizaciones_instalacion { get; set; }
    }
}
