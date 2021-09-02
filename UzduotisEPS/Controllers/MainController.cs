using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UzduotisEPS.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MainController : ControllerBase
	{
		private readonly IApplicationService _app;

		public MainController(IApplicationService applicationService)
		{
			_app = applicationService;
		}

		[HttpPost("Generate")]
		public IActionResult Generate(ushort count, byte length)
		{
			try
			{
				return Ok(_app.Generate(new GenerateViewModel() { Count = count, Length = length }));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UseCode")]
		public IActionResult UseCode(string code)
		{
			try
			{
				return Ok(Convert.ToByte(_app.UseCode(new UseCodeViewModel() { Code = code })));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}