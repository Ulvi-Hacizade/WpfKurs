using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOC_21Core.Domain.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        int Add(T obj);
        bool Update(T obj);
        bool Delete(int id);
        T FindById(int id);
        List<T> Get();
    }
}
