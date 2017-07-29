namespace SIC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel5")
        {
        }

        public virtual DbSet<articulos> articulos { get; set; }
        public virtual DbSet<cotizaciones_instalacion> cotizaciones_instalacion { get; set; }
        public virtual DbSet<cotizaciones_instalacion_articulos> cotizaciones_instalacion_articulos { get; set; }
        public virtual DbSet<empleados> empleados { get; set; }
        public virtual DbSet<empleados_asignados_instalacion> empleados_asignados_instalacion { get; set; }
        public virtual DbSet<empleados_venta_instalacion> empleados_venta_instalacion { get; set; }
        public virtual DbSet<niveles> niveles { get; set; }
        public virtual DbSet<proveedores> proveedores { get; set; }
        public virtual DbSet<servicios_instalacion> servicios_instalacion { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<cotizaciones_info> cotizaciones_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<articulos>()
                .Property(e => e.tipo_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<articulos>()
                .Property(e => e.nombre_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<articulos>()
                .Property(e => e.descripcion_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<articulos>()
                .Property(e => e.precio_Pro)
                .HasPrecision(8, 2);

            modelBuilder.Entity<articulos>()
                .HasMany(e => e.cotizaciones_instalacion_articulos)
                .WithRequired(e => e.articulos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .Property(e => e.mtscable_CotIns)
                .HasPrecision(5, 2);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .Property(e => e.totalcable_CotIns)
                .HasPrecision(8, 2);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .Property(e => e.observaciones_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .Property(e => e.complejidad_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .Property(e => e.total_CotIns)
                .HasPrecision(8, 2);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .Property(e => e.nombrecli_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .Property(e => e.domiciliocli_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .Property(e => e.correocli_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .HasMany(e => e.cotizaciones_instalacion_articulos)
                .WithRequired(e => e.cotizaciones_instalacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .HasMany(e => e.empleados_venta_instalacion)
                .WithRequired(e => e.cotizaciones_instalacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cotizaciones_instalacion>()
                .HasMany(e => e.servicios_instalacion)
                .WithRequired(e => e.cotizaciones_instalacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cotizaciones_instalacion_articulos>()
                .Property(e => e.precioactual_Art)
                .HasPrecision(8, 2);

            modelBuilder.Entity<empleados>()
                .Property(e => e.nombre_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.apaterno_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.amaterno_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.sexo_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.tipo_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.calle_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.colonia_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.correo_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.estadoc_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.conquienvive_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.familia_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.explaboral_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.especialidad_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .HasMany(e => e.empleados_asignados_instalacion)
                .WithRequired(e => e.empleados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<empleados>()
                .HasMany(e => e.empleados_venta_instalacion)
                .WithRequired(e => e.empleados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<empleados>()
                .HasOptional(e => e.usuarios)
                .WithRequired(e => e.empleados);

            modelBuilder.Entity<empleados>()
                .HasMany(e => e.niveles)
                .WithMany(e => e.empleados)
                .Map(m => m.ToTable("niveles_empleados").MapLeftKey("id_Emp").MapRightKey("id_Niv"));

            modelBuilder.Entity<empleados_venta_instalacion>()
                .Property(e => e.totalventa_EmpVenIns)
                .HasPrecision(8, 2);

            modelBuilder.Entity<empleados_venta_instalacion>()
                .Property(e => e.comision_EmpVenIns)
                .HasPrecision(8, 2);

            modelBuilder.Entity<niveles>()
                .Property(e => e.descripcion_Niv)
                .IsUnicode(false);

            modelBuilder.Entity<niveles>()
                .Property(e => e.pcomision_Niv)
                .HasPrecision(5, 2);

            modelBuilder.Entity<niveles>()
                .Property(e => e.venta_Niv)
                .HasPrecision(8, 2);

            modelBuilder.Entity<niveles>()
                .HasMany(e => e.empleados_venta_instalacion)
                .WithRequired(e => e.niveles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<proveedores>()
                .Property(e => e.nombre_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<proveedores>()
                .Property(e => e.giro_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<proveedores>()
                .Property(e => e.direccion_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<proveedores>()
                .Property(e => e.pagweb_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<proveedores>()
                .HasMany(e => e.articulos)
                .WithRequired(e => e.proveedores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<servicios_instalacion>()
                .Property(e => e.complejidad_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<servicios_instalacion>()
                .HasMany(e => e.empleados_asignados_instalacion)
                .WithRequired(e => e.servicios_instalacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.contraseña_Usu)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.nombre_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.apaterno_Emp)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.nombre_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.tipo_Pro)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.nombre_Art)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.mtscable_CotIns)
                .HasPrecision(5, 2);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.totalcable_CotIns)
                .HasPrecision(8, 2);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.observaciones_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.total_CotIns)
                .HasPrecision(8, 2);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.nombrecli_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.domiciliocli_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.correocli_CotIns)
                .IsUnicode(false);

            modelBuilder.Entity<cotizaciones_info>()
                .Property(e => e.complejidad_CotIns)
                .IsUnicode(false);
        }
    }
}
