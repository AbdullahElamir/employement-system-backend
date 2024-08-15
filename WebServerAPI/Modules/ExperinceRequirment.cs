using System;
using System.Collections.Generic;

namespace WebServerAPI.Modules;

public partial class ExperinceRequirment
{
    public int ExperienceRequirementId { get; set; }

    public string? Title { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public short? Status { get; set; }

    public short? ExperienceNumber { get; set; }

    public virtual ICollection<Career> Careers { get; set; } = new List<Career>();
}
