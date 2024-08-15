using System;
using System.Collections.Generic;

namespace WebServerAPI.Modules;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public byte[]? Image { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? LoginTryAttemptDate { get; set; }

    public short? LoginTryAttempts { get; set; }

    public DateTime? LastLoginOn { get; set; }

    /// <summary>
    /// 1- active 
    /// 2- not active by confirm his phone number otp 
    /// 3- suspended , wrong login attempts
    /// 0 -rejected
    /// 
    /// 
    /// </summary>
    public short? Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }
}
