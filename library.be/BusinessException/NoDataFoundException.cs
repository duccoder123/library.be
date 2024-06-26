namespace library.be.BusinessException
{
    [Serializable]
    public class NoDataFoundException : ExceptionHandling
    {
        public NoDataFoundException() : base("No data found.")
        {
            MessageCode = "no_data_found";
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}
