using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Messaging.Configuration
{
    public sealed class BrokerOptions
    {
        public const string SectionName = "BrokerOptions";

        public required string Host { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
