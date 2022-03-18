using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Dto
{
    public class BaseActionResultDto : IActionResultDto
    {

        public string msg { get; set; }
        public string result { get; set; }

        public BaseActionResultDto(string result, string msg) {
        
            this.result = result;
            this.msg = msg;

        }


    }
}
