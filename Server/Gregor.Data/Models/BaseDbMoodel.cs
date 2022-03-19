using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Data.Models
{
    public class BaseDbMoodel
    {
        public string id { get; set; }


        public BaseDbMoodel()
        {
            this.id=Guid.NewGuid().ToString();

        }

    }
}
