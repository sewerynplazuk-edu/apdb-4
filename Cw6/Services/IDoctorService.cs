using System;
using Cw6.Models.DTO;

namespace Cw6.Services
{
	public interface IDoctorService
	{
		Task<IEnumerable<DoctorDTO>> GetDoctors();
		Task AddDoctor(DoctorDTO doctorDTO);
		Task<bool> DoesDoctorExists(int idDoctor);
		Task UpdateDoctor(int idDoctor, DoctorDTO doctorDTO);
		Task DeleteDoctor(int idDoctor);
	}
}

