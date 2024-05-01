using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Business.Contract;
using Student.ViewModel.ViewModel;

namespace StudentPerformance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPerformanceController : ControllerBase
    {
        private readonly IStudentBusiness _studentBusiness;

        public StudentPerformanceController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        [HttpGet("GetTotalMarkObtained")]
        public async Task<ActionResult<decimal>> GetTotalMarkObtained([FromHeader] Guid StudentId)
        {
            var totalMarkObtained = await _studentBusiness.GetTotalMarkObtained(StudentId);
            return Ok(totalMarkObtained);
        }

        [HttpGet("GetTotalPercentageObtained")]
        public async Task<ActionResult<decimal>> GetTotalPercentageObtained([FromHeader] Guid StudentId)
        {
            var totalPercentageObtained = await _studentBusiness.GetTotalPercentageObtained(StudentId);
            return Ok(totalPercentageObtained);
        }

        [HttpGet("GetAllMarksById")]
        public async Task<ActionResult<List<MarksheetView>>> GetAllMarksById([FromHeader] Guid StudentId)
        {
            var marks = await _studentBusiness.GetAllMarksById(StudentId);
            return Ok(marks);
        }

        [HttpPost("AddMarks")]
        public async Task<ActionResult> AddMarks([FromBody] MarksheetView request)
        {
            await _studentBusiness.AddMarks(request);
            return Ok();
        }

        [HttpPost("UpdateMarks")]
        public async Task<ActionResult> UpdateMarks([FromBody] MarksheetView request)
        {
            await _studentBusiness.UpdateMarks(request);
            return Ok();
        }

        [HttpGet("GetStudentList")]
        public async Task<ActionResult<List<StudentView>>> GetStudentList([FromHeader] int classId)
        {
            var students = await _studentBusiness.GetStudentList(classId);
            return Ok(students);
        }

        [HttpGet("GetTopThree")]
        public async Task<ActionResult<List<StudentView>>> GetTopThree([FromHeader] int classId)
        {
            var topThreeStudents = await _studentBusiness.GetTopThree(classId);
            return Ok(topThreeStudents);
        }
    }
}
