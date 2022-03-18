using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Dto.Misc
{
    public class SystemStatusDto
    {
        public bool isAlive { get; }
        public string version { get; }
        public bool isDbAvailable { get; set; }
        public string dbPath { get; set; }

        public SystemStatusDto()
        {

            isAlive = true;
            version = "0.1";
            isDbAvailable = false;
            dbPath = "";

        }
    }



}
