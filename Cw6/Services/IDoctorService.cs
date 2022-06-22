using System;
using Cw6.Models.DTOs;

namespace Cw6.Services
{
	public interface IDoctorService
	{
		Task<IEnumerable<SomeKindOfDoctor>> GetDoctors();
		Task<SomeKindOfDoctor?> GetDoctor(int idDoctor);
		Task<bool> DoesDoctorExists(SomeKindOfDoctor doctorDTO);
		Task<bool> DoesDoctorExists(int idDoctor);
		Task AddDoctor(SomeKindOfDoctor doctorDTO);
		Task UpdateDoctor(int idDoctor, SomeKindOfDoctor doctorDTO);
		Task DeleteDoctor(int idDoctor);
	}
}

