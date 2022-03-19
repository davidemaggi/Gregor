using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Data.Models
{
    public class ConnectionModel:BaseDbMoodel
    {

        public string name { get; set; }
        public string? groupId { get; set; }
        public List<string> bootstrapServers { get; set; }
        public int commandTimeout { get; set; }

        public ConnectionModel() {
            
            this.name = "";
            this.bootstrapServers  = new List<string>();
            this.commandTimeout = 30;


        }

    }
}
