using EmployeeGraphQL.Repositories.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Repositories.Entities
{
    public class SalaryEntity : IDataEntity
    {
        public int Id { get; set; }

        public string SalaryCode { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
