using EmployeeGraphQL.Repositories.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Repositories.Entities
{
    public class DepartmentEntity : IDataEntity
    {
        public int Id { get; set; }

        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
