using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Domain.Shared
{
    public class BaseEntity
    {
        public DateTime DateOfCreation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; } = [];
    }
}
