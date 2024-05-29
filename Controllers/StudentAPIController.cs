using ASP.NET_Core_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentDbContext context;

        public StudentAPIController(StudentDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students.ToListAsync();

            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Student>> GetStudentById(int Id)
        {
            var student  =await context.Students.FindAsync(Id);
            if(student==null)return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();

            return Ok(std);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int Id,Student std)
        {
            if (Id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
          
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int Id)
        {
            var std = await context.Students.FindAsync(Id);
            if(std==null)return NotFound();

            context.Students.Remove(std);    
            await context.SaveChangesAsync();

            return Ok(std);
         
        }


    }
}
