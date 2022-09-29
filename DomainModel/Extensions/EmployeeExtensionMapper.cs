using DomainModel.DTO;
using DomainModel.Model;

namespace DomainModel.Extensions
{
    public static class EmployeeExtensionMapper
    {
        public static EmployeeDTO? ToBaseDTO(this Employee employee)
        {
            if (employee != null)
            {
                return new EmployeeDTO
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    BusinessId = employee.BusinessId,
                    Title = employee.Title,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                };
            }
            return null;
        }

        public static Employee? ToBaseEntity(this EmployeeDTO employee)
        {
            if (employee != null)
            {
                return new Employee
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    BusinessId = employee.BusinessId,
                    Title = employee.Title,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                };
            }
            return null;
        }
    }
}
