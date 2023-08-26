using DOC_21Core.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DOC_21Core.DataAccess.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly SqlContext context;
        private readonly string connString;
        public SqlUnitOfWork(string connString)
        {
            context = new SqlContext(connString);
            this.connString = connString;
        }

        

        public IUserRepository UserRepository => new SqlUserRepository(context);

        public IOrganizationRepository OrganizationRepository => new SqlOrganizationRepository(context);

        public ICourseRepository CourseRepository => new SqlCourseRepository(context);
        public IDocumentRepository DocumentRepository => new SqlDocumentRepository(context);

        //public IOrganizationRepository OrganizationRepository=>new
        //   public IBookRepository BookRepository => new SqlBookRepository(context);
        // public IBranchRepository BranchRepository => new SqlBranchRepository(context);

        public bool CheckServer()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
