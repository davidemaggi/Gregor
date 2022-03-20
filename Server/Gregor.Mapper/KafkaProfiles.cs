using AutoMapper;
using Confluent.Kafka;
using Gregor.Dto.Kafka;

namespace Gregor.MapService
{
    public class KafkaProfiles:Profile
    {
        public KafkaProfiles()
        {
            CreateMap<Metadata, SystemInfoDto>()
                .ForMember(dest => dest.brokerId, opt => opt.MapFrom(src => src.OriginatingBrokerId))
                .ForMember(dest => dest.brokerName, opt => opt.MapFrom(src => src.OriginatingBrokerName));


            CreateMap<TopicMetadata, TopicInfoDto>()
               .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Topic))
               //.ForMember(dest => dest.brokerName, opt => opt.MapFrom(src => src.))
               ;

        }
    }
}