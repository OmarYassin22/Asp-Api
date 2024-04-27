namespace Talabat.presentations.Errors
{
    public class ApiException : ApiResponease
    {
        private readonly string? details;

        public ApiException(int StatesCode, string? Message = null,string? Details=null) : base(StatesCode, Message)
        {
            details = Details;
        }
    }
}
