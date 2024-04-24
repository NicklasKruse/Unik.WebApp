using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Ínterfaces;
using Unik.Domain.Shared;
using Unik.Domain.ValueObjects;


namespace Unik.Domain.Models
{
    public class Booking : BaseEntity
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        //public string UserId { get; set; } Når vi laver login
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public Booking()
        {
            //EF
        }
        public Booking(List<Item> items, DateTime startDate, DateTime endDate) 
        {

            Items = items;
            StartDate = startDate;
            EndDate = endDate;

            //Validering af dato overlap
            // Preconditions
            // Logic

            //Postconditions
        }
        

        //Validering. Man må gerne have validering i WebApp.Models.ViewModels. Have validering tæt på brugeren, og hav validering hernede så der er universel dækning uanset om vi glemmer det, eller om vi laver en anden webapp

        public void Edit(List<Item> Items, DateTime startDate, DateTime endDate)
        {
            this.Items = Items;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

    }
    

}
