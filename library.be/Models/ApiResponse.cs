using Azure.Core.Pipeline;
using System.Net;

namespace library.be.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            ErrorMessages = new List<string>(); 
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } 
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
