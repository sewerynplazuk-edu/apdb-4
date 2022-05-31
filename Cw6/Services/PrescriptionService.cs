using System;
using Cw6.Models;
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

        async Task<PrescriptionDTO?> IPrescriptionService.GetPrescription(PrescriptionQueryDTO prescriptionQueryDTO)
        {
			var prescription = await _masterContext.Prescriptions.Where(prescription =>
				prescription.Patient.FirstName == prescriptionQueryDTO.Patient.FirstName &&
				prescription.Patient.LastName == prescriptionQueryDTO.Patient.LastName &&
				prescription.Doctor.FirstName == prescriptionQueryDTO.Doctor.FirstName &&
				prescription.Doctor.LastName == prescriptionQueryDTO.Doctor.LastName &&
				prescription.PrescriptionMedicaments.Any(prescriptionMedication =>
					prescriptionQueryDTO.Medications.Any(medication => medication.Name == prescriptionMedication.Medicament.Name)
				)
			).FirstOrDefaultAsync();
			if (prescription == null)
            {
				return null;
            }
			return new PrescriptionDTO
			{
				IdPrescription = prescription.IdPrescription,
				Date = prescription.Date,
				DueDate = prescription.DueDate
			};
        }
    }
}

