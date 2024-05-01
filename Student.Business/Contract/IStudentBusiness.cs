using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.ViewModel.ViewModel;

namespace Students.Business.Contract
{
    public interface IStudentBusiness
    {
        Task<decimal> GetTotalMarkObtained(Guid StudentId);
        Task<decimal> GetTotalPercentageObtained(Guid StudentId);
        Task<List<MarksheetView>> GetAllMarksById(Guid StudentId);
        Task AddMarks(MarksheetView request);
        Task UpdateMarks(MarksheetView request);
        Task<List<StudentView>> GetStudentList(int classId);
        Task<List<StudentView>> GetTopThree(int classId);
    }
}
