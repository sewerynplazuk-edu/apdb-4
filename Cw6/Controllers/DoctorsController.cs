using System;
using Cw6.Models.DTOs;
using Cw6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw6.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DoctorsController : ControllerBase
	{
		private readonly IDoctorService _doctorService;

		public DoctorsController(IDoctorService doctorService)
		{
			_doctorService = doctorService;
		}

        [HttpGet]
        public async Task<IActionResult> GetDoctor([FromQuery] int? idDoctor)
        {
			if (idDoctor == null)
			{
				var doctors = await _doctorService.GetDoctors();
				if (doctors == null || !doctors.Any())
				{
					return NotFound("Doctors not found");
				}
				return Ok(doctors);
			}
			else {
				var doctor = await _doctorService.GetDoctor(idDoctor.GetValueOrDefault());
				if (doctor == null)
				{
					return NotFound("Doctor with given id not found");
				}
				return Ok(doctor);
			}
		}


        [HttpPost]
		public async Task<IActionResult> AddDoctor(SomeKindOfDoctor doctorDTO)
        {
			if (await _doctorService.DoesDoctorExists(doctorDTO))
            {
				return BadRequest("Doctor already exists");
            }
			await _doctorService.AddDoctor(doctorDTO);
			return Ok();
        }

        [HttpPut]
		public async Task<IActionResult> UpdateDoctor(int idDoctor, SomeKindOfDoctor doctorDTO)
        {
			if (!await _doctorService.DoesDoctorExists(idDoctor))
            {
				return NotFound("Doctor with given id does not exist");
            }
			if (await _doctorService.DoesDoctorExists(doctorDTO))
			{
				return BadRequest("Doctor with given FirstName, LastName and Email already exists");
			}
			await _doctorService.UpdateDoctor(idDoctor, doctorDTO);
			return Ok();
        }

        [HttpDelete]
		public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
			if (!await _doctorService.DoesDoctorExists(idDoctor))
			{
				return NotFound("Doctor with given id does not exist");
			}
			await _doctorService.DeleteDoctor(idDoctor);
			return Ok();
		}
	}
}

