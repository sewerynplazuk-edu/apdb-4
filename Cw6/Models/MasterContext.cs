using System;
using Microsoft.EntityFrameworkCore;
namespace Cw6.Models
{
	public class MasterContext : DbContext
	{
		public MasterContext()
		{
		}

		public MasterContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Patient> Patients { get; set; } = null!;
		public DbSet<Doctor> Doctors { get; set; } = null!;
		public DbSet<Prescription> Prescriptions { get; set; } = null!;
		public DbSet<Medicament> Medicaments { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Patient>(patient =>
            {
				patient.HasKey(e => e.IdPatient);
				patient.Property(e => e.FirstName).HasMaxLength(100);
				patient.Property(e => e.LastName).HasMaxLength(100);
				patient.Property(e => e.BirthDate).HasColumnType("datetime");

				patient.HasData(
					new Patient { IdPatient = 1, FirstName = "Jan", LastName = "Kowalski", BirthDate = DateTime.Parse("1995-01-01")},
					new Patient { IdPatient = 2, FirstName = "Janina", LastName = "Kowalska", BirthDate = DateTime.Parse("1995-01-01") }
				);
			});

			modelBuilder.Entity<Doctor>(doctor =>
			{
				doctor.HasKey(e => e.IdDoctor);
				doctor.Property(e => e.FirstName).HasMaxLength(100);
				doctor.Property(e => e.LastName).HasMaxLength(100);
				doctor.Property(e => e.Email).HasMaxLength(100);

				doctor.HasData(
					new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jan.kowalski@lekarz.com"},
					new Doctor { IdDoctor = 2, FirstName = "Janina", LastName = "Kowalska", Email = "janina.kowalska@lekarz.com"}
				);
			});

			modelBuilder.Entity<Prescription>(prescription =>
			{
				prescription.HasKey(e => e.IdPrescription);
				prescription.Property(e => e.Date).HasColumnType("datetime");
				prescription.Property(e => e.DueDate).HasColumnType("datetime");
				prescription.HasOne(e => e.Patient)
						.WithMany(p => p.Prescriptions)
						.HasForeignKey(e => e.IdPatient)
						.OnDelete(DeleteBehavior.ClientSetNull);
				prescription.HasOne(e => e.Doctor)
						.WithMany(d => d.Prescriptions)
						.HasForeignKey(e => e.IdDoctor)
						.OnDelete(DeleteBehavior.ClientSetNull);

				prescription.HasData(
					new Prescription { IdPrescription = 1, Date = DateTime.Parse("2022-05-25"), DueDate = DateTime.Parse("2023-01-01"), IdDoctor = 1, IdPatient = 1 },
					new Prescription { IdPrescription = 2, Date = DateTime.Parse("2022-05-25"), DueDate = DateTime.Parse("2023-01-01"), IdDoctor = 2, IdPatient = 2 }
				);
			});

			modelBuilder.Entity<Medicament>(medicament =>
			{
				medicament.HasKey(e => e.IdMedicament);
				medicament.Property(e => e.Name).HasMaxLength(100);
				medicament.Property(e => e.Description).HasMaxLength(100);
				medicament.Property(e => e.Type).HasMaxLength(100);

				medicament.HasData(
					new Medicament { IdMedicament = 1, Name = "Apap", Description = "Na noc", Type = "Przeciwbólowy" },
					new Medicament { IdMedicament = 2, Name = "Ibuprofen", Description = "Na noc", Type = "Przeciwbólowy" }
				);
			});

			modelBuilder.Entity<PrescriptionMedicament>(prescriptionMedicament =>
			{
				prescriptionMedicament.HasKey(e => new { e.IdMedicament, e.IdPrescription });
				prescriptionMedicament.Property(e => e.Dose).IsRequired(false);
				prescriptionMedicament.HasOne(e => e.Medicament)
							.WithMany(m => m.PrescriptionMedicaments)
							.HasForeignKey(e => e.IdMedicament)
							.OnDelete(DeleteBehavior.ClientSetNull);
				prescriptionMedicament.HasOne(e => e.Prescription)
							.WithMany(p => p.PrescriptionMedicaments)
							.HasForeignKey(e => e.IdPrescription)
							.OnDelete(DeleteBehavior.ClientSetNull);

				prescriptionMedicament.HasData(
					new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "po posiłku" },
					new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 10, Details = "przed posiłkiem" }
				);
			});
		}
	}
}

