using System;
namespace Cw6.Models.DTOs
{
	public class SomeKindOfPrescription
	{
		public DateTime Date { get; set; }
		public DateTime DueDate { get; set; }
		public SomeKindOfDoctor Doctor { get; set; }
		public SomeKindOfPatient Patient { get; set; }
		public IEnumerable<SomeKindOfMedicament> Medicaments { get; set; }
	}
}

