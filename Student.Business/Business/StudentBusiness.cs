using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Student.Repository.Contract;
using Student.ViewModel.ViewModel;
using Students.Business.Contract;
using Students.Entity.Model;

namespace Students.Business.Business
{
    public class StudentBusiness : IStudentBusiness
    {
        public readonly IStudentRepository _studentRepository;
        public readonly IMapper _mapper;

        public StudentBusiness(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<decimal> GetTotalMarkObtained(Guid studentId)
        {
            var marks = await _studentRepository.GetAllMarksById(studentId);
            decimal totalMarkObtained = 0;
            foreach (var mark in marks)
            {
                totalMarkObtained += mark.MarksObtained ?? 0;
            }
            return totalMarkObtained;
        }

        public async Task<decimal> GetTotalPercentageObtained(Guid studentId)
        {
            var marks = await _studentRepository.GetAllMarksById(studentId);
            decimal totalMarkObtained = await GetTotalMarkObtained(studentId);
            decimal totalMarks = 0;
            foreach (var mark in marks)
            {
                totalMarks += mark.TotalMark ?? 0;
            }
            return (totalMarkObtained / totalMarks) * 100;
        }

        public async Task<List<MarksheetView>> GetAllMarksById(Guid studentId)
        {
            var marks = await _studentRepository.GetAllMarksById(studentId);
            var marksheetViews = _mapper.Map<List<MarksheetView>>(marks);
            return marksheetViews;
        }

        public async Task AddMarks(MarksheetView request)
        {
            var marksheet = _mapper.Map<MarkSheet>(request);
            await _studentRepository.AddMarks(marksheet);
        }

        public async Task UpdateMarks(MarksheetView request)
        {
            var marksheet = _mapper.Map<MarkSheet>(request);
            await _studentRepository.UpdateMarks(marksheet);
        }

        public async Task<List<StudentView>> GetStudentList(int classId)
        {
            var students = await _studentRepository.GetStudentsByClass(classId);
            var studentViews = _mapper.Map<List<StudentView>>(students);
            return studentViews;
        }

        public async Task<List<StudentView>> GetTopThree(int classId)
        {
            var topThreeStudents = await _studentRepository.GetTopThree(classId);
            var studentViews = _mapper.Map<List<StudentView>>(topThreeStudents);
            return studentViews;
        }
    }
}
