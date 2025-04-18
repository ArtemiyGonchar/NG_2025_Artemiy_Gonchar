using StoreManagmentBL.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentBL.Models
{
    public class VendorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? SignedAt { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public ContractTypeBL ContractType { get; set; }
    }
}
