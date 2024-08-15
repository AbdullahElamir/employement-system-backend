using System;
using System.Collections.Generic;

namespace WebServerAPI.Modules;

public partial class Education
{
    public int EducationId { get; set; }

    public string? Title { get; set; }

    public short? EducationNumber { get; set; }

    public DateTime? CreatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public short? Status { get; set; }
}
