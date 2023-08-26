using DOC_21Core.Domain.Abstract;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21Core.Factories
{
    public static class Kernel
    {
        public static IUnitOfWork Db { get; set; }
        public static User AuthenticatedUser { get; set; }
    }
}
