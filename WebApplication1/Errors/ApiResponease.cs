
using System.Text.Json;

namespace Talabat.presentations.Errors
{
    public class ApiResponease
    {
      
        public int StatesCode { get; set; }
        public string? Message { get; set; }

        public ApiResponease(int statesCode,string? message=null)
        {
            StatesCode = statesCode;
            Message = message ?? GetDefaultMessage(statesCode);
        }

        private  string? GetDefaultMessage(int statescode)
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
        //public override string ToString()
        //{
        //    return JsonSerializer.Serialize(new { statesCode,message});
        //}
    }
}
