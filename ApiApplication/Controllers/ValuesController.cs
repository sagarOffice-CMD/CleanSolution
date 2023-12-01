
using Application.DTO;
using Application.PersonCQ.Queries;
using Application.StudentCQ.Commands;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplication.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IValidator<Student> _validator;
        public ValuesController(IValidator<Student> validator)
        {
                _validator = validator;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await Mediator.Send(new GetsStudent()));
        }




        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> poststudent([FromBody] PostStudent student)
        {

            var result = await  _validator.ValidateAsync(student);
            if (result != null)
            {
                return BadRequest(result.Errors);
            }

            return Ok(await Mediator.Send(student));

        }
      
       



        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<string> PutStudent( [FromBody] GetStudentById Updatestudent)
        {
            
            return await Mediator.Send(Updatestudent);
        }





        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public async Task<string> DeleteStudent([FromBody] DeleteStudent Deletestudent)
        {
            return await Mediator.Send(Deletestudent);
            
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var st= await Mediator.Send(new GetById{ Id=id});
            return Ok(st);


        }
 
    }
}
