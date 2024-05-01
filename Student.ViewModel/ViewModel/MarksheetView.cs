using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.ViewModel.ViewModel
{
    public class MarksheetView
    {
        public Guid MarkSheetId { get; set; }

        public Guid? StudentId { get; set; }

        public string? Subject { get; set; }

        public decimal? TotalMark { get; set; }

        public decimal? MarksObtained { get; set; }

        public virtual StudentView? Student { get; set; }
    }
}
