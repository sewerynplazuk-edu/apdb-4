using System;
using Cw6.Models.DTOs;
namespace Cw6.Services
{
	public interface IPrescriptionService
	{
		Task<SomeKindOfPrescription> GetPrescription(int idPrescription);
	}
}

