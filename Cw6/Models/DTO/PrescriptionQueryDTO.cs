using System;
namespace Cw6
{
	public class PrescriptionQueryDTO
	{
		public DoctorPrescriptionDTO Doctor { get; set; } = null!;
		public PatientPrescriptionDTO Patient { get; set; } = null!;
		public IEnumerable<MedicationDTO> Medications { get; set; } = null!;
	}
}

