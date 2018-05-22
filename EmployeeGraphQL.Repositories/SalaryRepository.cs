using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Repositories
{
    public class SalaryRepository : BaseRepository<SalaryEntity>, ISalaryRepository
    {
        public SalaryEntity GetByCode(string salaryCode)
        {
            return new SalaryEntity() { SalaryCode = salaryCode, PaymentAmount = RandomGenerator.Next(500, 5000) };
        }

        public IEnumerable<SalaryEntity> GetByCodes(IEnumerable<string> salaryCodes)
        {
            foreach (var code in salaryCodes)
            {
                yield return new SalaryEntity() { SalaryCode = code, PaymentAmount = RandomGenerator.Next(500, 5000) };
            }
        }
    }
}
