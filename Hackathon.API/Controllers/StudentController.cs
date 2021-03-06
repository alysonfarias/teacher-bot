using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Params;
using Hackathon.Application.Roles;
using Hackathon.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.Admin)]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentResponse>> GetAsync([FromQuery] UserParams<Student> queryParams)
        {
            return await _studentService.GetAsync(queryParams);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentResponse>> GetByIdAsync(int id)
        {
            return await _studentService.GetByIdAsync(id);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<StudentResponse>> PostAsync([FromBody] StudentRequest student)
        {
            return await _studentService.RegisterAsync(student);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StudentResponse>> PutAsync([FromBody] StudentRequest student, [FromRoute] int id)
        {
            return await _studentService.UpdateAsync(student, id);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<StudentResponse>> DeleteAsync(int id)
        {
            return await _studentService.RemoveAsync(id);
        }

        [HttpGet("user-roles")]
        public IEnumerable<UserRoleResponse> GetUserRoles()
        {
            return _studentService.GetUserRoles();
        }
    }
}