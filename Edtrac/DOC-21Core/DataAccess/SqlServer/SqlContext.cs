using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOC_21Core.DataAccess.SqlServer
{
    public class SqlContext
    {
        public string ConnString { get; }
        public SqlContext(string connString)
        {
            ConnString = connString;
        }
    }
}
