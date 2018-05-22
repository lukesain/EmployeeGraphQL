using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeGraphQL.Domain.Services
{
    public class EmployeeService : BaseService<Employee, EmployeeEntity>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = null;
        private readonly IDepartmentService _departmentService = null;
        private readonly ISalaryService _salaryService = null;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentService departmentService, ISalaryService salaryService)
        {
            _employeeRepository = employeeRepository;

            _departmentService = departmentService;
            _salaryService = salaryService;
        }

        public IEnumerable<Employee> FindByName(string name)
        {
            IEnumerable<EmployeeEntity> employeesByFirstName = _employeeRepository.GetByFirstName(name);
            IEnumerable<EmployeeEntity> employeesByLastName = _employeeRepository.GetByLastName(name);

            var employees = employeesByFirstName.ToList();
            employees.AddRange(employeesByLastName);

            IEnumerable<SalaryInfo> salaryInfos = _salaryService.GetByCodes(employees.Select(x => x.SalaryCode));
            IEnumerable<DepartmentInfo> departments = _departmentService.GetByCodes(employees.Select(x => x.DepartmentCode));

            return Map(employees, salaryInfos, departments);
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _employeeRepository.GetAll();

            IEnumerable<SalaryInfo> salaryInfos = _salaryService.GetByCodes(employees.Select(x => x.SalaryCode));
            IEnumerable<DepartmentInfo> departments = _departmentService.GetByCodes(employees.Select(x => x.DepartmentCode));

            return Map(employees, salaryInfos, departments);
        }

        public Employee GetById(int id)
        {
            EmployeeEntity employeeEntity = _employeeRepository.GetById(id);

            DepartmentInfo departmentInfo = _departmentService.GetByCode(employeeEntity.DepartmentCode);
            SalaryInfo salaryInfo = _salaryService.GetByCode(employeeEntity.SalaryCode);


            return Map(employeeEntity, salaryInfo, departmentInfo);
        }

        private Employee Map(EmployeeEntity employeeEntity, SalaryInfo salaryInfo, DepartmentInfo departmentInfo)
        {
            return new Employee()
            {
                FirstName = employeeEntity.FirstName,
                LastName = employeeEntity.LastName,
                JobTitle = employeeEntity.JobTitle,
                EmploymentDate = employeeEntity.EmploymentDate,
                Profile = new PersonalInfo()
                {
                    DateOfBith = employeeEntity.DateOfBirth,
                    MonthlySalary = salaryInfo.Amount
                },
                Department = new DepartmentInfo()
                {
                    Code = employeeEntity.DepartmentCode,
                    Name = departmentInfo.Name
                }
            };
        }

        private IEnumerable<Employee> Map(IEnumerable<EmployeeEntity> employees, IEnumerable<SalaryInfo> salaryInfos, IEnumerable<DepartmentInfo> departments)
        {
            foreach (var employee in employees)
            {
                yield return Map(employee, salaryInfos.First(x => x.Code == employee.SalaryCode), departments.First(x => x.Code == employee.DepartmentCode));
            }
        }
    }
}
