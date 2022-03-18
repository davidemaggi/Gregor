using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gregor.Data.Repositories;
using Gregor.Dto.Misc;
using Gregor.Dto;
using Gregor.Dto.System;
using System.Net.Mime;

namespace Gregor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SystemController : ControllerBase
    {

        private IGregorRepository _gregorRepository;

        public SystemController(IGregorRepository gregorRepository) {
            _gregorRepository = gregorRepository;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ActionName("status")]
        public BaseResultDto<SystemStatusDto> getStatus()
        {
            try {
                var ret = new SystemStatusDto();

                ret.isDbAvailable = _gregorRepository.isDbAvailable();
                ret.dbPath = _gregorRepository.getDbPath();

                return BaseResultDto<SystemStatusDto>.success(ret);
            }
            catch(Exception) {
                return BaseResultDto<SystemStatusDto>.error(null,"Error Retrieving System Status");

            }

        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
 
        [ActionName("initDb")]
        public BaseResultDto<BaseActionResultDto> initDb([FromBody] InitDbRequestDto req)
        {
            try
            {
                var ret = _gregorRepository.initDb("gregor",$"gregor{req.password}");
                return BaseResultDto<BaseActionResultDto>.fromAction(ret);
            }
            catch (Exception)
            {
                return BaseResultDto<BaseActionResultDto>.error(null, "Error Creating Db");

            }


           
        }


    }
}
