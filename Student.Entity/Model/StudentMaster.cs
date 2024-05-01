using System;
using System.Collections.Generic;

namespace Students.Entity.Model;

public partial class StudentMaster
{
    public Guid StudentId { get; set; }

    public string? StudentName { get; set; }

    public DateTimeOffset? StudentJoinDate { get; set; }

    public int? Class { get; set; }

    public virtual ICollection<MarkSheet> MarkSheets { get; set; } = new List<MarkSheet>();
}
