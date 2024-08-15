using System;
using System.Collections.Generic;

namespace WebServerAPI.Modules;

public partial class Location
{
    public long LocationId { get; set; }

    public string? Name { get; set; }

    public string? Descriptions { get; set; }

    public DateTime? CreatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public short? Status { get; set; }

    public virtual ICollection<Career> Careers { get; set; } = new List<Career>();
}
