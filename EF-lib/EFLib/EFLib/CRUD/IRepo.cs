using EFLib.Models;
using System;
using System.Collections.Generic;

namespace EFLib.CRUD
{
    interface IRepo<T> where T : BaseClass
    {
        int Add(T entity);
        int AddOrUpdate(T entity);
        int AddRange(IList<T> entities);
        int Update(T entity);
        int Delete(Guid id);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetAll();
    }
}
