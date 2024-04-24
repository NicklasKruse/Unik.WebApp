using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Domain.Shared
{
    public class BaseEntity  //Egentlig bare for at have rowversion på alle entities
    {
        [Timestamp]
        public byte[] RowVersion { get; private set; } = [];
    }
}
