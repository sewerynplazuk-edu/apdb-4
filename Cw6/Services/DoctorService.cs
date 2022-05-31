using System;
using Cw6.Models;
using Cw6.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cw6.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly MasterContext _masterContext;

		public DoctorService(MasterContext masterContext)
		{
			_masterContext = masterContext;
		}

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
			return await _masterContext.Doctors
					.Select(doctor => new DoctorDTO
					{
						FirstName = doctor.FirstName,
						LastName = doctor.LastName,
						Email = doctor.Email
					}).ToListAsync();
        }

        async Task IDoctorService.AddDoctor(DoctorDTO doctorDTO)
        {
			var lastDoctorOrderedById = await _masterContext.Doctors.OrderBy(d => d.IdDoctor).LastAsync();
			var nextIdDoctor = lastDoctorOrderedById.IdDoctor + 1;

			var doctor = new Doctor
			{
				IdDoctor = nextIdDoctor,
				FirstName = doctorDTO.FirstName,
				LastName = doctorDTO.LastName,
				Email = doctorDTO.Email
			};

			_masterContext.Add(doctor);
			await _masterContext.SaveChangesAsync();
        }

        async Task<bool> IDoctorService.DoesDoctorExists(int idDoctor)
        {
			var count = await _masterContext.Doctors.CountAsync(d => d.IdDoctor == idDoctor);
			return count == 1;
        }

        Task<IEnumerable<DoctorDTO>> IDoctorService.GetDoctors()
        {
            throw new NotImplementedException();
        }

        async Task IDoctorService.UpdateDoctor(int idDoctor, DoctorDTO doctorDTO)
        {
			var doctor = await _masterContext.Doctors.Where(d => d.IdDoctor == idDoctor).FirstOrDefaultAsync();
			if (doctor == null)
            {
				throw new Exception("This method assumes that doctor was added to the database");
            }
			doctor.FirstName = doctorDTO.FirstName;
			doctor.LastName = doctorDTO.LastName;
			doctor.Email = doctorDTO.Email;

			_masterContext.Update(doctor);
			await _masterContext.SaveChangesAsync();
        }

		async Task IDoctorService.DeleteDoctor(int idDoctor)
		{
			var doctor = await _masterContext.Doctors.Where(d => d.IdDoctor == idDoctor).FirstOrDefaultAsync();
			if (doctor == null)
			{
				throw new Exception("This method assumes that doctor was added to the database");
			}
			_masterContext.Remove(doctor);
			await _masterContext.SaveChangesAsync();
		}
	}
}

