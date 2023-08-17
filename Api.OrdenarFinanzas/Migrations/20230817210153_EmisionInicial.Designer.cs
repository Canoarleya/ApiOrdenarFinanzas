﻿// <auto-generated />
using System;
using Api.OrdenarFinanzas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.OrdenarFinanzas.Migrations
{
    [DbContext(typeof(ApiOrdenarFinanzasDBContext))]
    [Migration("20230817210153_EmisionInicial")]
    partial class EmisionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.Client", b =>
                {
                    b.Property<long>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCliente"));

                    b.Property<string>("Apellido1Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellido2Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombresCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroDocCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelContactoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.GastoFijo", b =>
                {
                    b.Property<long>("IdGastoFijo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdGastoFijo"));

                    b.Property<string>("DescripcionGastoFijo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdPeriodicidad")
                        .HasColumnType("bigint");

                    b.Property<long>("IdTipoGastoFijo")
                        .HasColumnType("bigint");

                    b.Property<decimal>("MontoEstimado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("PeriodicidadIdPeriodicidad")
                        .HasColumnType("bigint");

                    b.Property<long?>("TipoGastoFijoIdTipoGastoFijo")
                        .HasColumnType("bigint");

                    b.HasKey("IdGastoFijo");

                    b.HasIndex("PeriodicidadIdPeriodicidad");

                    b.HasIndex("TipoGastoFijoIdTipoGastoFijo");

                    b.ToTable("GastoFijo", (string)null);
                });

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.Periodicidad", b =>
                {
                    b.Property<long>("IdPeriodicidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdPeriodicidad"));

                    b.Property<string>("DescripcionPeriodicidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPeriodicidad");

                    b.ToTable("Periodicidad", (string)null);
                });

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.TipoGastoFijo", b =>
                {
                    b.Property<long>("IdTipoGastoFijo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTipoGastoFijo"));

                    b.Property<string>("DescripcionTipoGastoFijo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("IdTipoGastoFijo");

                    b.HasIndex("UserId");

                    b.ToTable("TipoGastoFijo", (string)null);
                });

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.UserRole", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.GastoFijo", b =>
                {
                    b.HasOne("Api.OrdenarFinanzas.Data.Models.Periodicidad", "Periodicidad")
                        .WithMany()
                        .HasForeignKey("PeriodicidadIdPeriodicidad");

                    b.HasOne("Api.OrdenarFinanzas.Data.Models.TipoGastoFijo", "TipoGastoFijo")
                        .WithMany()
                        .HasForeignKey("TipoGastoFijoIdTipoGastoFijo");

                    b.Navigation("Periodicidad");

                    b.Navigation("TipoGastoFijo");
                });

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.TipoGastoFijo", b =>
                {
                    b.HasOne("Api.OrdenarFinanzas.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.OrdenarFinanzas.Data.Models.User", b =>
                {
                    b.HasOne("Api.OrdenarFinanzas.Data.Models.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}