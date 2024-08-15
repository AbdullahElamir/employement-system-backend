using System;
using System.Collections.Generic;

namespace WebServerAPI.Modules;

public partial class Career
{
    public long CareerId { get; set; }

    public string? Title { get; set; }

    public string? Descriptions { get; set; }

    public string? Requirements { get; set; }

    public int? ExperienceRequirementId { get; set; }

    public int? EducationId { get; set; }

    /// <summary>
    /// 1- Full-Time
    /// 2- Part-Time
    /// 3- Contract
    /// 4-Temporary
    /// 5- Remote
    /// 
    /// </summary>
    public short? PostionType { get; set; }

    public long? LocationId { get; set; }

    public int? Salary { get; set; }

    public bool? IsPublished { get; set; }

    public DateTime? ApplicationExpirationDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public short? Status { get; set; }

    public string? RefrenceCode { get; set; }

    public virtual ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();

    public virtual ExperinceRequirment? ExperienceRequirement { get; set; }

    public virtual Location? Location { get; set; }
}
