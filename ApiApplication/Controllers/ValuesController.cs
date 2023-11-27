using Application.PersonCQ.Queries;
using Application.StudentCQ.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplication.Controllers
{
    public class ValuesController : ApiController
    {


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await Mediator.Send(new GetsStudent());
        }




        // POST api/<ValuesController>
        [HttpPost]
        public async Task<string> poststudent([FromBody] PostStudent student)
        {
            return await Mediator.Send(student);

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

        [HttpGet("{GetById}")]
        public async Task<string> GetStudentById([FromBody] GetById GetStudentById)
        {
            return await Mediator.Send(GetStudentById);

        }
    }
}
