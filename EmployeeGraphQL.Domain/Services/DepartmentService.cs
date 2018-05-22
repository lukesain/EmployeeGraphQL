using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Domain.Services
{
    public class DepartmentService : BaseService<DepartmentInfo, DepartmentEntity>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public DepartmentInfo GetByCode(string departmentCode)
        {
            DepartmentEntity departmentEntity = _departmentRepository.GetByCode(departmentCode);

            return Map(departmentEntity);
        }

        public IEnumerable<DepartmentInfo> GetByCodes(IEnumerable<string> departmentCodes)
        {
            IEnumerable<DepartmentEntity> departmentEntities = _departmentRepository.GetByCodes(departmentCodes);

            return Map(departmentEntities);
        }

        public override DepartmentInfo Map(DepartmentEntity item)
        {
            return new DepartmentInfo() { Code = item.DepartmentCode, Name = item.DepartmentName };
        }

        public override IEnumerable<DepartmentInfo> Map(IEnumerable<DepartmentEntity> items)
        {
            foreach (var item in items)
            {
                yield return Map(item);
            }
        }
    }
}
