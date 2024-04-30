namespace Talabat.presentations.Errors
{
    public class ApiException : ApiResponease
    {
        public string? Details { get; set; }

        public ApiException(int StatesCode=500, string? Message = null,string? details = null) : base(StatesCode, Message)
        {
            Details = details;
        }
    }
}
