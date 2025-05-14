using Helper;
using System.Net;

namespace Application.Common
{
    public class CustomError
    {
        public static readonly Error GenerateJibitTokenFail = new("01", "Generate jibit token fail", HttpStatusCode.BadRequest);
        public static readonly Error GenerateJibitPayIdFail = new("02", "Generate jibit payId fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitPayIdInfoFail = new("03", "Jibit payId info fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitPayIdInquiryFail = new("04", "Jibit payId inquiry fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitPayIdVerifyFail = new("05", "Jibit payId verify fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitPayIdFail = new("06", "Jibit payId fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitTransferFail = new("07", "Jibit transfer fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitInquiryTransferFail = new("08", "Jibit inquiry transfer fail", HttpStatusCode.BadRequest);
        public static readonly Error InvalidJibitTransferParameters = new("09", "Invalid jibit inquiry parameters", HttpStatusCode.BadRequest);
        public static readonly Error JibitDeleteTransferFail = new("10", "Jibit delete transfer fail", HttpStatusCode.BadRequest);
        public static readonly Error JibitRetryTransferFail = new("11", "Jibit retry transfer fail", HttpStatusCode.BadRequest);
        public static readonly Error InvalidClientBatchId = new("12", "Invalid client batchId", HttpStatusCode.BadRequest);
        public static readonly Error ScheduleJobFail = new("13", "Schedule job fail", HttpStatusCode.BadRequest);
        public static readonly Error TransferModelNotFound = new("14", "Transfer model not found", HttpStatusCode.BadRequest);
    }
}
