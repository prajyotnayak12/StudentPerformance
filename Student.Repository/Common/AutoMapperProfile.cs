using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Students.Entity.Model;
using Student.ViewModel.ViewModel;

namespace Student.Repository.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentMaster, StudentView>();
            CreateMap<StudentView, StudentMaster>();

            CreateMap<MarkSheet, MarksheetView>();
            CreateMap<MarksheetView, MarkSheet>();
        }
    }
}
