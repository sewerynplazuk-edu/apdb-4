using System;
using Cw6.Models;
using Cw6.Models.DTOs;
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

		public async Task<IEnumerable<SomeKindOfDoctor>> GetDoctors()
		{
			return await _masterContext.Doctors
					.Select(doctor => new SomeKindOfDoctor
					{
						FirstName = doctor.FirstName,
						LastName = doctor.LastName,
						Email = doctor.Email
					}).ToListAsync();
        }

		public async Task<SomeKindOfDoctor?> GetDoctor(int idDoctor)
        {
			return await _masterContext.Doctors
					.Where(doctor => doctor.IdDoctor == idDoctor)
					.Select(doctor => new SomeKindOfDoctor
					{
						FirstName = doctor.FirstName,
						LastName = doctor.LastName,
						Email = doctor.Email
					}).FirstOrDefaultAsync();
        }

		public async Task<bool> DoesDoctorExists(SomeKindOfDoctor doctorDTO)
		{
			var doctor = await _masterContext.Doctors
				.Where(doctor => doctor.FirstName == doctorDTO.FirstName && doctor.LastName == doctorDTO.LastName && doctor.Email == doctorDTO.Email)
				.FirstOrDefaultAsync();
			return doctor is not null; 
		}


		public async Task<bool> DoesDoctorExists(int idDoctor)
        {
			var doctor = await _masterContext.Doctors
				.Where(doctor => doctor.IdDoctor == idDoctor)
				.FirstOrDefaultAsync();
			return doctor is not null;
        }

		public async Task AddDoctor(SomeKindOfDoctor doctorDTO)
		{
			var doctor = new Doctor
			{
				FirstName = doctorDTO.FirstName,
				LastName = doctorDTO.LastName,
				Email = doctorDTO.Email
			};

			_masterContext.Add(doctor);
			await _masterContext.SaveChangesAsync();
		}

		public async Task UpdateDoctor(int idDoctor, SomeKindOfDoctor doctorDTO)
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

		public async Task DeleteDoctor(int idDoctor)
		{
			var doctor = new Doctor { IdDoctor = idDoctor };
			_masterContext.ChangeTracker.Clear();
			_masterContext.Attach(doctor);
			_masterContext.Remove(doctor);
			await _masterContext.SaveChangesAsync();
		}
    }
}

