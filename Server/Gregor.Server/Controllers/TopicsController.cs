using Gregor.Data.Models;
using Gregor.Data.Repositories;
using Gregor.Data.Statics;
using Gregor.Dto;
using Gregor.Dto.Kafka;
using Gregor.Dto.Misc;
using Gregor.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Gregor.Server.Controllers
{
    [Route("api/Kafka/[controller]/[action]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {


        private IGregorRepository _gregorRepository;
        private IKafkaService _kafkaService;



        public TopicsController(IGregorRepository gregorRepository, IKafkaService kafkaService)
        {
            _gregorRepository = gregorRepository;
            _kafkaService = kafkaService;
        }


        [HttpGet("{connectionId}")]
        [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ActionName("getAll")]
        public BaseResultDto<List<TopicInfoDto>> getAll(string connectionId)
        {
            try
            {

                var ret = this._kafkaService.getConnection(connectionId)?.Topic.getAll();

                if (ret == null)
                {
                    return BaseResultDto<List<TopicInfoDto>>.error(null, $"Error Getting Topic  List to {connectionId}");

                }

                return BaseResultDto<List<TopicInfoDto>>.success(ret);







            }
            catch (Exception ex)
            {
                return BaseResultDto<List<TopicInfoDto>>.error(null, $"Error Connecting to {connectionId}: {ex.Message}");

            }

        }

        }
    }
