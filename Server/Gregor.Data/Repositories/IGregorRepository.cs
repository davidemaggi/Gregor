using Gregor.Dto;
using Gregor.Dto.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Data.Repositories
{
    public interface IGregorRepository
    {

        public bool isDbAvailable();
        public string getDbPath();
        public BaseActionResultDto initDb(string userName, string password, bool withData=true);


        public T getSingle<T>(string coll, string id);
    }
}
