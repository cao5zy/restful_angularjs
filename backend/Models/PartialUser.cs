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
            this.DateOfBirthStr = this.DateOfBirth != null ? this.DateOfBirth.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : ""; 
        }
        [OnDeserialized]
        void OnDeserializing(StreamingContext ctx)
        {
            this.DateOfBirth = DateTime.ParseExact(this.DateOfBirthStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        public string DateOfBirthStr { get; set; }
    }
}
