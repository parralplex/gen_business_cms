
using DomainModel.DTO.Abstract;
using DomainModel.Model;

namespace DomainModel.DTO
{
    public class EmployeeDTO : IDTO<Employee>
    {
        public int EmployeeId { get; set; }
        public int BusinessId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Title { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

        public override void CopyDataToEntity(Employee oldEntity)
        {
            oldEntity.FirstName = FirstName;
            oldEntity.PhoneNumber = PhoneNumber;
            oldEntity.Email = Email;    
            oldEntity.Title = Title;
            oldEntity.LastName = LastName;
            oldEntity.EmployeeId = EmployeeId;
            oldEntity.BusinessId = BusinessId;
        }

        public override Employee ToBaseEntity()
        {
            return new Employee
            {
                EmployeeId = EmployeeId,
                FirstName = FirstName,
                LastName = LastName,
                BusinessId = BusinessId,
                Title = Title,
                PhoneNumber = PhoneNumber,
                Email = Email,
            };
        }
    }
}
