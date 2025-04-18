using PetStoreBL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreBL.Models
{
    public class PetStoreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public PetTypesBL Type { get; set; }
        public Guid StoreId { get; set; }
        // ICollection<HealthCare> HealthCares { get; set; }
    }
}
