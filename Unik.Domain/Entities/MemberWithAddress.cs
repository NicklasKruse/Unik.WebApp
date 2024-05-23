using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Shared;
using Unik.Domain.ValueObjects;

namespace Unik.Domain.Entities
{
    public class MemberWithAddress : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        //public Roles Role { get; set; }
        //public bool IsFormerBoardMember { get; set; }
        public MemberWithAddress()
        {
            //EF
        }
        public MemberWithAddress(string firstName, string lastName, string email, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }
    }
}
