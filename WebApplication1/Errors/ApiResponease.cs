
namespace Talabat.presentations.Errors
{
    public class ApiResponease
    {
        public readonly int statesCode;
        public readonly string? message;

        public ApiResponease(int StatesCode,string? Message=null)
        {
            this.statesCode = StatesCode;
            message = Message ?? GetDefaultMessage(StatesCode);
        }

        private string? GetDefaultMessage(int statescode)
        {
            return statescode switch
            {
                400 => "Bad Request",
                401 => "Not Authorized",
                404 => "Not Found",
                500=>"Server Not Found",
                _ => ""
            };
        }
    }
}
