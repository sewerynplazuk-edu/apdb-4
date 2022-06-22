using System;
using Cw6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw6.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PrescriptionsController : ControllerBase
	{
		private readonly IPrescriptionService _prescriptionService;

		public PrescriptionsController(IPrescriptionService prescriptionService)
		{
			_prescriptionService = prescriptionService;
		}

        [HttpGet]
		public async Task<IActionResult> GetPrescription([FromQuery] int idPrescription)
        {
			var result = await _prescriptionService.GetPrescription(idPrescription);
			if (result == null) {
				return NotFound("Prescription with given id not found");
			}
			return Ok(result);
        }
	}
}

