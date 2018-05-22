using System.Collections.Generic;
using EmployeeGraphQL.Repositories.Entities;

namespace EmployeeGraphQL.Domain.Services
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentInfo> GetByCodes(IEnumerable<string> enumerable);
        DepartmentInfo GetByCode(string departmentCode);
    }
}