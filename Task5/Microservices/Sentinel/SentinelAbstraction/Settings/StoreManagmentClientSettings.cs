﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelAbstraction.Settings
{
    public class StoreManagmentClientSettings
    {
        public const string SectionName = "StoreManagmentClient";

        public string BaseAddress { get; set; } = string.Empty;
    }
}
