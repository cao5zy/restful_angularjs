using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rule
    {
        public string ValidExpression { get; set; }
        public List<string> BlackList { get; set; }
    }
}
