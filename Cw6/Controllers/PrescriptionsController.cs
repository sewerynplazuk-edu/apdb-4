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
		public async Task<IActionResult> GetPrescription(PrescriptionQueryDTO prescription)
        {
			var result = await _prescriptionService.GetPrescription(prescription);
			if (result == null) {
				return NotFound("No prescriptions");
			}
			return Ok(result);
        }
	}
}

