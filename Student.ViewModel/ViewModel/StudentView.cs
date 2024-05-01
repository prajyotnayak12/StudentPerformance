using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.ViewModel.ViewModel
{
    public class StudentView
    {
        public Guid StudentId { get; set; }

        public string? StudentName { get; set; }

        public DateTimeOffset? StudentJoinDate { get; set; }

        public int? Class { get; set; }

        public virtual ICollection<MarksheetView> MarkSheets { get; set; } = new List<MarksheetView>();
    }
}
