using EmployeeGraphQL.Repositories.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeGraphQL.Repositories
{
    public abstract class BaseRepository<T> where T : IDataEntity
    {
        protected Random RandomGenerator = new Random(DateTime.Now.Day);
        private List<int> usedIds = new List<int>();

        private static object _padlock = new object();

        protected static Dictionary<int, T> Data
        {
            get
            {
                if (_data == null)
                {
                    lock (_padlock)
                    {
                        if (_data == null)
                        {
                            _data = new Dictionary<int, T>();
                        }
                    }
                }
                return _data;
            }
        }
        private static Dictionary<int, T> _data;

        protected virtual int FetchNextId()
        {
            int id = RandomGenerator.Next(3021, 9999);
            while (usedIds.Any(x => x == id))
            {
                id = RandomGenerator.Next(3021, 9999);
            }
            usedIds.Add(id);

            return id;
        }

        public IEnumerable<T> GetAll()
        {
            return Data.Values;
        }

        public T ById(int id)
        {
            return Data.Values.SingleOrDefault(x => x.Id == id);
        }
    }
}