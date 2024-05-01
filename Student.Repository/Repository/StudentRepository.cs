using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Entity.Model;
using Student.Repository.Contract;

namespace Student.Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public readonly StudentContext _dbContext;

        public StudentRepository(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MarkSheet>> GetAllMarksById(Guid studentId)
        {
            return await _dbContext.MarkSheets.Where(m => m.StudentId == studentId).ToListAsync();
        }

        public async Task<StudentMaster> GetStudentById(Guid studentId)
        {
            return await _dbContext.StudentMasters.FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task<List<StudentMaster>> GetStudents()
        {
            return await _dbContext.StudentMasters.ToListAsync();
        }
        public async Task<List<StudentMaster>> GetStudentsByClass(int classId)
        {
            return await _dbContext.StudentMasters.Where(s => s.Class == classId).ToListAsync();
        }
        public async Task<List<StudentMaster>> GetTopThree(int classId)
        {
            return await _dbContext.StudentMasters
                .Where(s => s.Class == classId)
                .OrderByDescending(s => s.MarkSheets.Sum(m => m.TotalMark)) 
                .Take(3)
                .ToListAsync();
        }

        public async Task UpdateMarks(MarkSheet marksheet)
        {
            _dbContext.Entry(marksheet).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddMarks(MarkSheet marksheet)
        {
            await _dbContext.MarkSheets.AddAsync(marksheet);
            await _dbContext.SaveChangesAsync();
        }
    }
}