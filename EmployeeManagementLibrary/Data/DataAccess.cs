using EmployeeManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary.Data
{
	public class DataAccess : IDataAccess
	{
		private List<EmployeeModel> _employees = new();

		public DataAccess()
		{
			_employees.Add(new EmployeeModel { Id = 1, FirstName = "Abir ", LastName = "Choudhury" });
			_employees.Add(new EmployeeModel { Id = 2, FirstName = "Chandana", LastName = "Sarkar" });
		}

		public List<EmployeeModel> GetEmployees()
		{
			return _employees;
		}

		public EmployeeModel AddEmployee(string firstName, string lastName)
		{
			EmployeeModel newEmployee = new() { FirstName = firstName, LastName = lastName };
			newEmployee.Id = _employees.Max(x => x.Id) + 1;
			return newEmployee;
		}
	}
}
