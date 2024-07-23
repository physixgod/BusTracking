﻿// <auto-generated />
using BusTracking.Infrastructure.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusTracking.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240722100425_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusTracking.Domain.ENTITIES.Societe", b =>
                {
                    b.Property<int>("SocieteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocieteId"));

                    b.HasKey("SocieteId");

                    b.ToTable("Societe");
                });

            modelBuilder.Entity("BusTracking.Domain.ENTITIES.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SocieteId")
                        .HasColumnType("int");

                    b.HasKey("Login");

                    b.HasIndex("SocieteId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BusTracking.Domain.ENTITIES.User", b =>
                {
                    b.HasOne("BusTracking.Domain.ENTITIES.Societe", "Societe")
                        .WithMany("Users")
                        .HasForeignKey("SocieteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Societe");
                });

            modelBuilder.Entity("BusTracking.Domain.ENTITIES.Societe", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
