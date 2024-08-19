namespace WebServerAPI.DTOs
{
    public class CareerDTO
    {
        public long CareerId { get; set; }
        public string? Title { get; set; }
        public string? Descriptions { get; set; }
        public string? Requirements { get; set; }
        public int? ExperienceRequirementId { get; set; }
        public int? EducationId { get; set; }
        public short? PostionType { get; set; }
        public long? LocationId { get; set; }
        public int? Salary { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? ApplicationExpirationDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public short? Status { get; set; }
        public string? RefrenceCode { get; set; }
    }
}
