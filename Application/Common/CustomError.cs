using Helper;
using System.Net;

namespace Application.Common
{
    public class CustomError
    {
        public static readonly Error GenerateJibitTokenFail = new("01", "Generate jibit token fail", HttpStatusCode.BadRequest);
        public static readonly Error GenerateJibitPayIdFail = new("02", "Generate jibit payId fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitPayIdInfoFail = new("03", "jibit payId info fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitPayIdInquiryFail = new("04", "jibit payId inquiry fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitPayIdVerifyFail = new("05", "jibit payId verify fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitPayIdFail = new("06", "jibit payId fail", HttpStatusCode.BadRequest);
    }
}
