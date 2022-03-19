using Gregor.Data.Models;
using Gregor.Dto;
using Gregor.Enums;
using Gregor.Kafka.KafkaObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Kafka
{
    public class KafkaService:IKafkaService
    {

        private List<KafkaConnection> _connections { get; set; }

        public KafkaService()
        {

            this._connections=new List<KafkaConnection>();

        }

        public KafkaConnection? getConnection(string id)=> this._connections.Find(x => x.id.Equals(id));

           
        

            public BaseActionResultDto connect(ConnectionModel conn)
        {
            try
            {
                var exists = this._connections.Find(x => x.id.Equals(conn.id));

                if (exists != null)
                {
                    return new BaseActionResultDto(Result.WARNING, $"Already Connected to {conn.name}");
                }

                this._connections.Add(new KafkaConnection(conn));

                return new BaseActionResultDto(Result.OK, $"Connected to {conn.name}");


            }
            catch (Exception ex) { 
            
                return new BaseActionResultDto(Result.OK, $"Error Connecting to {conn.name}: {ex.Message}");


            }



        }
    }
}
