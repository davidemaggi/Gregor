using Gregor.Data.Models;
using Gregor.Data.Repositories;
using Gregor.Data.Statics;
using Gregor.Dto;
using Gregor.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gregor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KafkaController : ControllerBase
    {



        private IGregorRepository _gregorRepository;
        private IKafkaService _kafkaService;

        public KafkaController(IGregorRepository gregorRepository, IKafkaService kafkaService)
        {
            _gregorRepository = gregorRepository;
            _kafkaService = kafkaService;
        }

        [HttpGet("{connectionId}")]
        [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ActionName("connectTo")]
        public BaseResultDto<BaseActionResultDto> connectTo(string connectionId)
        {
            try
            {

                var conf = this._gregorRepository.getSingle<ConnectionModel>(Collections.Connections, connectionId);

                var ret = this._kafkaService.connect(conf);

                

                return BaseResultDto<BaseActionResultDto>.success(ret);
            }
            catch (Exception ex)
            {
                return BaseResultDto<BaseActionResultDto>.error(null, $"Error Connecting to {connectionId}: {ex.Message}");

            }

        }


    }
}
