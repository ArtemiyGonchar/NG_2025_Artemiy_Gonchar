﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentBL.Models
{
    public class PetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
    }
}
