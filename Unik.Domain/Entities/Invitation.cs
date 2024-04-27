using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Shared;
using Unik.Domain.ValueObjects;

namespace Unik.Domain.Entities
{
    public class Invitation : BaseEntity
    {
        public int Id { get; set; }
        public string? Description { get; set; }//Hvad skal der stå i invitationen. Kan også være tom
        public DateTime Date { get; set; }
        //public List<InvitationAcceptance> Acceptances { get; private set; } = new List<InvitationAcceptance>();
        internal Invitation()
        {
            //Ef
        }
        public Invitation(string? description, DateTime date)
        {
            Description = description;
            Date = date;

            //validering af dato overlap
        }
        public void Edit(string? description, DateTime date)//Edit er som sådan ikke Businesslogic. Opdatere bare properties og derfor kan den være i entiteten. Bruges sammen med Load i repository. Så kan vi skilde vores Entities fra vores DTO'er
        {
            Description = description;
            Date = date;
        }

    }
}
