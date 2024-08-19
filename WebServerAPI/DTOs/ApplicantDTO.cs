namespace WebServerAPI.DTOs
{
    public class ApplicantDTO
    {
        public long ApplicantId { get; set; }
        public string? Nid { get; set; }
        public string? FirstName { get; set; }
        public string? FatherName { get; set; }
        public string? GrandFatherName { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public int? SalaryExpectations { get; set; }
        public byte[]? Resume { get; set; }
        public string? CoverLetter { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }
        public long? CareerId { get; set; }
    }
}
