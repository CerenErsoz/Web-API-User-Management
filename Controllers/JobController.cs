using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.JobOperations.Commands.CreateJob;
using WebApi.Applications.JobOperations.Commands.DeleteJob;
using WebApi.Applications.JobOperations.Commands.UpdateJob;
using WebApi.Applications.JobOperations.Queries.GetJobDetail;
using WebApi.Applications.JobOperations.Queries.GetJobs;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]

    public class JobController : ControllerBase
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;


        public JobController(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetJobs()
        {
            GetJobsQuery query = new GetJobsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("id")]
        public IActionResult GetJobDetail(int id)
        {
            GetJobDetailQuery query = new GetJobDetailQuery(_context, _mapper);
            query.JobId = id;
            GetJobDetailValidator validator = new GetJobDetailValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddJob([FromBody] CreateJobModel newJob)
        {
            CreateJobCommand command = new CreateJobCommand(_context);
            command.Model = newJob;
            CreateJobCommandValidator validator = new CreateJobCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }


        [HttpPut("id")]
        public IActionResult UpdateJob(int id, [FromBody] UpdateJobModel updateJob)
        {
            UpdateJobCommand command = new UpdateJobCommand(_context);
            command.JobId = id;
            command.Model = updateJob;
            UpdateJobCommandValidator validator = new UpdateJobCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }


        [HttpDelete("id")]
        public IActionResult DeleteJob(int id)
        {
            DeleteJobCommand command = new DeleteJobCommand(_context);
            command.JobId = id;
            DeleteJobCommandValidator validator = new DeleteJobCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}