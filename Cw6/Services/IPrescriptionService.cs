using System;
namespace Cw6.Services
{
	public interface IPrescriptionService
	{
		Task<PrescriptionDTO?> GetPrescription(PrescriptionQueryDTO prescriptionQueryDTO);
	}
}

