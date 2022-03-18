using Gregor.Enums;

namespace Gregor.Dto
{
    public class BaseResultDto<T>
    {
        public string result { get; }
        public string msg { get; }
        public T? data { get; }
        public long timestamp { get; }

        public BaseResultDto(string result, T? data, string msg="") {

            
            this.result = result;
            this.data = data;
            this.msg = msg;
            this.timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }


        public static BaseResultDto<T> success(T? data, string msg = "") => new BaseResultDto<T>(Result.OK, data, msg);
        public static BaseResultDto<T> error(T? data, string msg = "") => new BaseResultDto<T>(Result.ERROR, data, msg);
        public static BaseResultDto<T> warning(T? data, string msg = "") => new BaseResultDto<T>(Result.WARNING, data, msg);
        public static BaseResultDto<BaseActionResultDto> fromAction(BaseActionResultDto actionRes) => new BaseResultDto<BaseActionResultDto>(actionRes.result, actionRes, actionRes.msg);

        public bool isOk()
        {

            return new[] { Result.OK, }.Contains(this.result);

        }

        public bool isNotError()
        {

            return new[] { Result.OK, Result.WARNING, }.Contains(this.result);

        }


    }
}