using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Domain.Services
{
    public class SalaryService : BaseService<SalaryInfo, SalaryEntity>, ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public SalaryInfo GetByCode(string salaryCode)
        {
            SalaryEntity salaryEntity = _salaryRepository.GetByCode(salaryCode);

            return Map(salaryEntity);
        }

        public IEnumerable<SalaryInfo> GetByCodes(IEnumerable<string> salaryCodes)
        {
            IEnumerable<SalaryEntity> salaryEntities = _salaryRepository.GetByCodes(salaryCodes);

            return Map(salaryEntities);
        }

        public override IEnumerable<SalaryInfo> Map(IEnumerable<SalaryEntity> items)
        {
            foreach (var salaryEntity in items)
            {
                yield return Map(salaryEntity);
            }
        }

        public override SalaryInfo Map(SalaryEntity entity)
        {
            return new SalaryInfo() { Code = entity.SalaryCode, Amount = entity.PaymentAmount };
        }
    }
}
