using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gregor.Server.Controllers
{
    [Route("api/Kafka/[controller]/[action]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
    }
}
