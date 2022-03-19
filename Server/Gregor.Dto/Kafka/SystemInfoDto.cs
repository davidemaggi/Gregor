using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Dto.Kafka
{
    public class SystemInfoDto
    {
        public string? brokerName { get; set; }
        public string? brokerId { get; set; }
    }
}
