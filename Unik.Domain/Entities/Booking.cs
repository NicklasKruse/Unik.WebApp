using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.DomainServices;
using Unik.Domain.Ínterfaces;
using Unik.Domain.Shared;
using Unik.Domain.ValueObjects;


namespace Unik.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public string UserId { get; set; } //Medlem opretter en booking. På booking skriver man sin email/UserId
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Booking()
        {
            //EF
        }
        public Booking(Item item, DateTime startDate, DateTime endDate)
        {

            Item = item;
            StartDate = startDate;
            EndDate = endDate;
            //Validering af dato overlap
            // Preconditions
            // Logic

            //Postconditions
        }


        //Validering. Man må gerne have validering i WebApp.Models.ViewModels. Have validering tæt på brugeren, og hav validering hernede så der er universel dækning uanset om vi glemmer det, eller om vi laver en anden webapp

        public void Edit(Item Item, DateTime startDate, DateTime endDate) //Kan ændre datoerne men ikke userid. Man kan også ændre Item
        {
            this.Item = Item;
            StartDate = startDate;
            EndDate = endDate;
        }

    }


}
