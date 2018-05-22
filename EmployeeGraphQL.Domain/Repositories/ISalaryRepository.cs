using System;
using System.Collections.Generic;
using System.Text;
using EmployeeGraphQL.Repositories.Entities;

namespace EmployeeGraphQL.Domain.Repositories
{
    public interface ISalaryRepository
    {
        IEnumerable<SalaryEntity> GetByCodes(IEnumerable<string> salaryCodes);
        SalaryEntity GetByCode(string salaryCode);
    }
}
