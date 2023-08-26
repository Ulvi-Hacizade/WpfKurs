using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Models
{
    public abstract class BaseModel
    {
        public abstract object this[string name] { get; }

        public int No { get; set; }
        public int Id { get; set; }
    }
}
