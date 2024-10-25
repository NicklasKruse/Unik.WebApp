﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppFront.Services.Models.Invitation
{
    public class InvitationCreateRequestDto
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
