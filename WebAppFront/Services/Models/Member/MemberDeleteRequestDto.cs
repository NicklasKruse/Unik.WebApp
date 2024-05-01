using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppFront.Services.Models.Member
{
    public class MemberDeleteRequestDto // Ikke i brug
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public string UserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
