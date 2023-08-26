using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOC_21Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        bool CheckServer();

        IUserRepository UserRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        ICourseRepository CourseRepository { get; }
        IDocumentRepository DocumentRepository { get; }
       

    }
}
