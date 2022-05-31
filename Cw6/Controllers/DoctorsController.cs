using System;
using Cw6.Models.DTO;
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
		public async Task<IActionResult> GetDoctors()
        {
			var doctors = await _doctorService.GetDoctors();
			return Ok(doctors);
        }

        [HttpPost]
		public async Task<IActionResult> AddDoctor(DoctorDTO doctorDTO)
        {
			await _doctorService.AddDoctor(doctorDTO);
			return Ok();
        }

        [HttpPut]
		public async Task<IActionResult> UpdateDoctor(int idDoctor, DoctorDTO doctorDTO)
        {
			if (!await _doctorService.DoesDoctorExists(idDoctor))
            {
				return NotFound("Doctor with given id does not exist");
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

