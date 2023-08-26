using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOC_21Core.Domain.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUsername(string username);
    }
}
