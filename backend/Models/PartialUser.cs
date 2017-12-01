using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class User
    {

        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            this.DateOfBirthStr = this.DateOfBirth != null ? this.DateOfBirth.Value.ToShortDateString() : ""; 
        }
        public string DateOfBirthStr { get; set; }
    }
}
