using Gregor.Data.Models;
using Gregor.Data.Statics;
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

        private readonly string  _username;
        private readonly string _password;

        public GregorRepository(string username, string password) {
        
            _username = username;
            _password = password;

        }

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

        private LiteDatabase connectDb()
        {
            return new LiteDatabase($"Filename={this.getDbPath()};Password={Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(_password))}");
        }

        public BaseActionResultDto initDb(bool withData=true)
        {

            if (this.isDbAvailable())
            {
                return new BaseActionResultDto(Result.WARNING, "DB is already Present");
            }

            try {
                Directory.CreateDirectory(getGregorPath());

                using (var db= this.connectDb()) {


                    var colConnections = db.GetCollection<ConnectionModel>(Collections.Connections);


                    if (withData)
                    {
                        colConnections.Insert(new ConnectionModel()
                        {
                            name = "Test",
                            bootstrapServers = new List<string>() { "192.168.1.2:9092"},
                            
                        });



                    }


                    colConnections.EnsureIndex(x => x.name);



                }






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



        public T getSingle<T>(string coll, string id)
        {

            T? ret = default(T);

            using (var db = this.connectDb())
            {
                ret = db.GetCollection<T>(coll).FindById(id);
            }

            return ret;
        }


    }
}
