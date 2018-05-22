using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Repositories
{
    public class DepartmentRepository : BaseRepository<DepartmentEntity>, IDepartmentRepository
    {
        public DepartmentEntity GetByCode(string departmentCode)
        {
            return new DepartmentEntity() { DepartmentCode = departmentCode, DepartmentName = "Room #" + RandomGenerator.Next(1, 101) };
        }

        public IEnumerable<DepartmentEntity> GetByCodes(IEnumerable<string> departmentCodes)
        {
            foreach (var code in departmentCodes)
            {
                yield return new DepartmentEntity() { DepartmentCode = code, DepartmentName = "Room #" + RandomGenerator.Next(1, 101) };
            }
        }
    }
}
