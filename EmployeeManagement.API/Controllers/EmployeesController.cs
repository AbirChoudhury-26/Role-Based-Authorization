using EmployeeManagementLibrary.Commands;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IMediator _mediator;

		 public EmployeesController(IMediator mediator)
		{
			_mediator = mediator;

		}

		[HttpGet]

		public async Task<List<EmployeeModel>>Get()
		{
			return await _mediator.Send(new GetEmployeeListQuery());
		}

		[HttpGet("{id}")]
		 public async Task<EmployeeModel>Get(int id)
		{
			return await _mediator.Send(new GetEmployeeByIdQuery(id));
		}

		[HttpPost]

		public async Task<EmployeeModel> Post([FromBody]EmployeeModel emp)
		{
			return await _mediator.Send(new AddEmployeeCommand(emp.FirstName, emp.LastName));
		}
	}
}
