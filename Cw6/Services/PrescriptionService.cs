using System;
using Cw6.Models;
using Cw6.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Cw6.Services
{
	public class PrescriptionService : IPrescriptionService
	{
		private readonly MasterContext _masterContext;

		public PrescriptionService(MasterContext masterContext)
		{
			_masterContext = masterContext;
		}

		public async Task<SomeKindOfPrescription> GetPrescription(int idPrescription)
        {
			return await _masterContext.Prescriptions
                .Where(prescription => prescription.IdPrescription == idPrescription)
				.Select(prescription => new SomeKindOfPrescription
				{
					Date = prescription.Date,
					DueDate = prescription.DueDate,
					Doctor = new SomeKindOfDoctor
                    {
                        FirstName = prescription.Doctor.FirstName,
						LastName = prescription.Doctor.LastName,
						Email = prescription.Doctor.Email
                    },
					Patient = new SomeKindOfPatient
                    {
						FirstName = prescription.Patient.FirstName,
						LastName = prescription.Patient.LastName,
						BirthDate = prescription.Patient.BirthDate
                    },
					Medicaments = prescription.PrescriptionMedicaments
						.Select(prescriptionMedicament => new SomeKindOfMedicament
                        {
							Name = prescriptionMedicament.Medicament.Name,
							Description = prescriptionMedicament.Medicament.Description,
							Type = prescriptionMedicament.Medicament.Type,
							PrescribedDose = prescriptionMedicament.Dose,
							PrescriptionDetails = prescriptionMedicament.Details
                        })
				}).FirstOrDefaultAsync();
        }
    }
}

