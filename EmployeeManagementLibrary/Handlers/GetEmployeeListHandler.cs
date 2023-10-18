using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagementLibrary.Handlers
{
	public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeModel>>
	{
		private readonly IDataAccess _dataAccess;

		// This part promotes Dependency Injection as :
		//  An instance of GetEmployeeListHandler is created (usually by a dependency injection container), it receives an instance of IDataAccess through the constructor.
		public GetEmployeeListHandler(IDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public Task<List<EmployeeModel>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_dataAccess.GetEmployees()); // Since GetEmployee which is defined in IdataAccess is having a type of List,

			// So, the handler function is returning the type of response as List only .
		}
	}
}
