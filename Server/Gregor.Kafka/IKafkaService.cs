using Gregor.Data.Models;
using Gregor.Dto;
using Gregor.Kafka.KafkaObjects;

namespace Gregor.Kafka
{
    public interface IKafkaService
    {

        public BaseActionResultDto connect(ConnectionModel conn);
        public KafkaConnection? getConnection(string id);

    }
}