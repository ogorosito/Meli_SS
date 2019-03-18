﻿// <auto-generated />
using ML.SistemaSolar.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ML.SistemaSolar.Migrations
{
    [DbContext(typeof(CondicionClimaticaContext))]
    [Migration("20190315152356_ML.SistemaSolar.EF.CondicionClimaticaContext")]
    partial class MLSistemaSolarEFCondicionClimaticaContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ML.SistemaSolar.EF.CondicionClimatica", b =>
                {
                    b.Property<int>("Dia");

                    b.Property<bool>("EsPeriodoDeLluvia");

                    b.Property<bool>("EsPeriodoDeSequia");

                    b.Property<bool>("HayCondicionesOptimasDeTemperatura");

                    b.Property<double>("PerimetroTriangulo");

                    b.HasKey("Dia");

                    b.ToTable("CondicionesClimaticas");
                });
#pragma warning restore 612, 618
        }
    }
}