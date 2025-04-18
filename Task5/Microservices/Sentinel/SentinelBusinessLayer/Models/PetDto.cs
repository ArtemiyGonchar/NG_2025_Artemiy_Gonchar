using SentinelBusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Models
{
    public class PetDto
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public PetTypesBL Type { get; set; }
        public Guid StoreId { get; set; }
    }
}
