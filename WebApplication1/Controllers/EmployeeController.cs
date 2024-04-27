using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Access.Models.Company;
using Talabat.Access.Specifications.CompanySpecification;
using Talabat.Core.Interfaces.Repository;
using Talabat.presentaion.Controllers;
using Talabat.presentations.DTOs;
using Talabat.presentations.Errors;
using Talabat.Repo.Repositories;

namespace Talabat.presentations.Controllers
{
   
    public class EmployeeController : BaseAPIController
    {
        private readonly EmployeeReps _employee;
        private readonly IMapper mapper;

        public EmployeeController(EmployeeReps employee, IMapper mapper)
        {
            _employee = employee;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllwithSpecification()
        {
            var spec = new EmployeeWithDepartmentSpecification();
            var emps = await _employee.GetAllWithSpecAsync(spec);
            if(emps?.Count() >0)
                return Ok();
            return BadRequest("No Employee!!!!!!!!!!!!!!!");
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Employee), 200)]
        public async Task<ActionResult<Employee>> GetWithSpec(int id) { 
        
            var spec = new EmployeeWithDepartmentSpecification(id);
            if (spec is not null)
                return Ok(await _employee.GetByIdWithSpecAsync(spec));
            return NotFound(new ApiResponease(404));

        }


        [HttpPost("employee")]
        public async Task<ActionResult> AddEmployee(EmployeeDTO employee) { 
        
            var emp= mapper.Map<Employee>(employee);

            emp.DepartmentId = 1;
            emp.Department = new Department() { Id = 1, Name = "HR" };


            if (await _employee.AddAsync(emp) !=0)
            {
                return Ok(employee);
            }
            return BadRequest(employee);



        }
    }
}
