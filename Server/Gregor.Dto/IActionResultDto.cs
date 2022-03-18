using Gregor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Dto
{
    public interface IActionResultDto
    {
        string result { get; set; }
        string msg { get; set; }


        public bool isOk()
        {

            return new[] { Result.OK, }.Contains(this.result);

        }

        public bool isNotError()
        {

            return new[] { Result.OK, Result.WARNING, }.Contains(this.result);

        }

    }
}
