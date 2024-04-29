namespace Talabat.presentations.Errors
{
    public class ApiException : ApiResponease
    {
        public string? Details { get; set; }

        public ApiException(int StatesCode, string? Message = null,string? details = null) : base(StatesCode, Message)
        {
            Details = details;
        }
    }
}
