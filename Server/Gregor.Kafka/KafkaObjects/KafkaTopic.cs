using Confluent.Kafka;
using Gregor.Dto.Kafka;
using Gregor.MapService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Kafka.KafkaObjects
{
    public class KafkaTopic
    {

        KafkaConnection _connection;
        private readonly MapperService _mapperService = new MapperService();

        public KafkaTopic(KafkaConnection kafkaConnection)
        {
            _connection = kafkaConnection;
        }


        public List<TopicInfoDto> getAll()
        {

            var ret = new List<TopicInfoDto>();


            var all = _connection._adminClient.GetMetadata(TimeSpan.FromSeconds(_connection._connectionConfig.commandTimeout)).Topics.ToList();


            return _mapperService._mapper.Map<List<TopicMetadata>,List<TopicInfoDto>>(all, ret);
        }

    }
}
