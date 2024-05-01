using Students.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Repository.Contract
{
    public interface IStudentRepository
    {
        Task<List<MarkSheet>> GetAllMarksById(Guid studentId);
        Task<StudentMaster> GetStudentById(Guid studentId);
        Task<List<StudentMaster>> GetStudents();
        Task<List<StudentMaster>> GetTopThree(int classId);
        Task UpdateMarks(MarkSheet marksheet);
        Task AddMarks(MarkSheet marksheet);
        Task<List<StudentMaster>> GetStudentsByClass(int classId);
    }
}
