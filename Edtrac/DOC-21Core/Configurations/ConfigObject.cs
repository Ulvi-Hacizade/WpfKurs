using DOC_21Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOC_21Core.Configurations
{
    public class ConfigObject
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool IsWindowsAuthentication { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public SqlServerType SqlServerType { get; set; }
    }
}
