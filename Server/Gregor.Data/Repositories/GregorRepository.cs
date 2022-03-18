using Gregor.Dto;
using Gregor.Dto.System;
using Gregor.Enums;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Data.Repositories
{
    public class GregorRepository : IGregorRepository
    {
        public string getGregorPath()
        {

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return Path.Combine(appDataPath, "Gregor");
        }

        public string getDbPath()
        {

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return Path.Combine(getGregorPath(),"Gregor.db");
        }

        public BaseActionResultDto initDb(string userName, string password="")
        {

            if (this.isDbAvailable())
            {
                return new BaseActionResultDto(Result.WARNING, "DB is already Present");
            }

            try {
                Directory.CreateDirectory(getGregorPath());

                using (var db = new LiteDatabase($"Filename={this.getDbPath()};Password={Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password))}")) { }

                    return new BaseActionResultDto(Result.OK,"DB Created");

            }
            catch (Exception ex) {
                return new BaseActionResultDto(Result.ERROR, "DB Not Created: "+ex.Message);

            }


        }

        public bool isDbAvailable()
        {
            return File.Exists(getDbPath());
        }
    }
}
