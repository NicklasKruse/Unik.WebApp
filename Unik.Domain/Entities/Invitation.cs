using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Shared;

namespace Unik.Domain.Entities
{
    public class Invitation : BaseEntity
    {
        public int Id { get; set; }
        public string? Description { get; set; }//Hvad skal der stå i invitationen. Kan også være tom
        public DateTime Date { get; set; }
        public Invitation()
        {
            
        }
        public Invitation(string? description, DateTime date)
        {
            Description = description;
            Date = date;

            //validering af dato overlap
        }
    }
}
