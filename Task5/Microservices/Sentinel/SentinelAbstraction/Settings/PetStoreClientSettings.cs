using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelAbstraction.Settings
{
    public class PetStoreClientSettings
    {
        public const string SectionName = "PetStoreClient";

        public string BaseAddress { get; set; } = string.Empty;
    }
}
