using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PhoneBook.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Single(object primaryKey);

        IEnumerable<T> GetAll();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        bool Exists(Expression<Func<T, bool>> where);
    }
}