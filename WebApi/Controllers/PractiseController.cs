using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PractiseController : Controller
	{
		private readonly IPractiseRepository _practiseRepository;

		public PractiseController(IPractiseRepository practiseRepository)
		{
			_practiseRepository = practiseRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var entities = await _practiseRepository.GetAll();

			return Ok(entities);
		}

		[HttpGet("View")]
		public async Task<IActionResult> GetSQLView()
		{
			var sqlView = await _practiseRepository.GetSQLView();

			return Ok(sqlView);
		}


		[HttpGet("GetTeamByName")]
		public async Task<IActionResult> GetTeamByName(string teamName)
		{
			var storedProcedureResult = await _practiseRepository.GetTeamByName(teamName);

			return Ok(storedProcedureResult);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id, string? teamName, int? leagueId)
		{
			var entity = await _practiseRepository.GetById(id)!;
            //var entity = await _practiseRepository.GetByIdAndWithOptionalParameters(id, teamName, leagueId)!;

            return Ok(entity);
		}

		[HttpPost]
		public async Task<ActionResult> Create(Team team)
		{
			var createdEntity = await _practiseRepository.Create(team);

			return Ok(createdEntity);
		}

		[HttpPut]
		public async Task<ActionResult> Update(Team team)
		{
			var createdEntity = await _practiseRepository.Update(team);

			return Ok(createdEntity);
		}
	}
}