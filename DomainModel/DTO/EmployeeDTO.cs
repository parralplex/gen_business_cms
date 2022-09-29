
namespace DomainModel.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int BusinessId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Title { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
