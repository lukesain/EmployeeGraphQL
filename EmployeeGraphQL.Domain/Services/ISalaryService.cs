using System.Collections.Generic;
using EmployeeGraphQL.Repositories.Entities;

namespace EmployeeGraphQL.Domain.Services
{
    public interface ISalaryService
    {
        IEnumerable<SalaryInfo> GetByCodes(IEnumerable<string> enumerable);
        SalaryInfo GetByCode(string salaryCode);
    }
}