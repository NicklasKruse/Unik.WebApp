using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Commands.Item.DTO
{
    public class ItemDeleteRequestDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Damage { get; set; }
    }
}
