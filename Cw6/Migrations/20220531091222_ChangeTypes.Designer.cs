﻿// <auto-generated />
using System;
using Cw6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cw6.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20220531091222_ChangeTypes")]
    partial class ChangeTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cw6.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "jan.kowalski@lekarz.com",
                            FirstName = "Jan",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "janina.kowalska@lekarz.com",
                            FirstName = "Janina",
                            LastName = "Kowalska"
                        });
                });

            modelBuilder.Entity("Cw6.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Na noc",
                            Name = "Apap",
                            Type = "Przeciwbólowy"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Na noc",
                            Name = "Ibuprofen",
                            Type = "Przeciwbólowy"
                        });
                });

            modelBuilder.Entity("Cw6.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            BirthDate = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jan",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdPatient = 2,
                            BirthDate = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Janina",
                            LastName = "Kowalska"
                        });
                });

            modelBuilder.Entity("Cw6.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 2,
                            IdPatient = 2
                        });
                });

            modelBuilder.Entity("Cw6.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription");

                    b.HasIndex("IdPrescription");

                    b.ToTable("PrescriptionMedicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "po posiłku",
                            Dose = 1
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 2,
                            Details = "przed posiłkiem",
                            Dose = 10
                        });
                });

            modelBuilder.Entity("Cw6.Models.Prescription", b =>
                {
                    b.HasOne("Cw6.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .IsRequired();

                    b.HasOne("Cw6.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Cw6.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("Cw6.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .IsRequired();

                    b.HasOne("Cw6.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .IsRequired();

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Cw6.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Cw6.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("Cw6.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Cw6.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
