using System;
using System.Collections.Generic;
using System.Text;
using EmployeeGraphQL.Repositories.Entities;

namespace EmployeeGraphQL.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        DepartmentEntity GetByCode(string departmentCode);
        IEnumerable<DepartmentEntity> GetByCodes(IEnumerable<string> departmentCodes);
    }
}
