using System.Globalization;
using System.Net;

namespace library.be.BusinessException
{
    [Serializable]
    public class ExceptionHandling :  Exception
    {
        public ExceptionHandling(string errorMessage) : base(errorMessage)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }
        public ExceptionHandling(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
            StatusCode = HttpStatusCode.BadRequest;
        }
        public Object ToSerializableObject()
        {
            return new
            {
                MessageCode,
                StatusCode,
                Message,
                StackTrace
            };
        }

        public string MessageCode { get;set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
