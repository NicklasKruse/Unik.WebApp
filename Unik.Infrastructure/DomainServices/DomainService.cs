using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Shared;
using Unik.Domain.ValueObjects;

namespace Unik.Infrastructure.DomainServices
{
    public class DomainService // Lav noget service til at tjekke om der er overlap i datoer. skal bruges både i invitation og booking
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        private int _dateInterval;

        public int DateInterval
        {
            get => _dateInterval;
            private set => _dateInterval = value;
        }

        //private void CalculateDateInterval() => _dateInterval = (EndDate - StartDate).Days;
    }
}
