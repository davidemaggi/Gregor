using Confluent.Kafka;
using Gregor.Data.Models;
using Gregor.Dto.Kafka;
using Gregor.MapService;
using Gregor.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.Kafka.KafkaObjects
{
    public class KafkaConnection
    {

        private readonly IConsumer<string,string> _consumer;
        private readonly IProducer<string,string> _producer;
        private readonly IAdminClient _adminClient;
        private readonly ConnectionModel _connectionConfig;
        private readonly MapperService _mapper=new MapperService();

        public readonly string id;

        public KafkaConnection(ConnectionModel conn) {

            this._connectionConfig = conn;
            this._consumer = new ConsumerBuilder<string, string>(getConsumerConfig()).Build();
            this._producer = new ProducerBuilder<string, string>(getProducerConfig()).Build();
            this._adminClient = new AdminClientBuilder(getAdminConfig()).Build();

            this.id = this._connectionConfig.id;

        }


        public SystemInfoDto getServerInfo()
        {
            var ret = new SystemInfoDto();

            var metaData = this._adminClient.GetMetadata(TimeSpan.FromSeconds(this._connectionConfig.commandTimeout));





            return _mapper.map(metaData,ret);
        }


        private AdminClientConfig getAdminConfig()
        {

            var conf = new AdminClientConfig
            {
                BootstrapServers = String.Join(',',this._connectionConfig.bootstrapServers),

            };

            return conf;

        }

        private ConsumerConfig getConsumerConfig()
        {

            var conf = new ConsumerConfig
            {
                GroupId = string.IsNullOrEmpty(this._connectionConfig.groupId) ? $"Gregor-{StringTools.randomString(5)}" : this._connectionConfig.groupId,
                BootstrapServers = String.Join(',', this._connectionConfig.bootstrapServers),
                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            return conf;

        }

        private ProducerConfig getProducerConfig()
        {

            var conf = new ProducerConfig
            {
                BootstrapServers = String.Join(',', this._connectionConfig.bootstrapServers),

            };

            return conf;

        }



    }
}
