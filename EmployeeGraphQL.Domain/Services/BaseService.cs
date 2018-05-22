using System;
using System.Collections.Generic;

namespace EmployeeGraphQL.Domain.Services
{
    public abstract class BaseService<T1, T2>
    {
        public virtual IEnumerable<T1> Map(IEnumerable<T2> items)
        {
            throw new NotImplementedException("This should be overridden");
        }

        public virtual T1 Map(T2 item)
        {
            throw new NotImplementedException("This should be overridden");
        }
    }
}