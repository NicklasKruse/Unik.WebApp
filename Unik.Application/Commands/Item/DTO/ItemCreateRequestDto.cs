using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Commands.Item.DTO
{
    public class ItemCreateRequestDto
    {
        public string Description { get; set; }
        //Behøver ikke at blive oprettet med damage. Det kan tilføjes i Edit
    }
}
