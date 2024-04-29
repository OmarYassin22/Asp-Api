namespace Talabat.presentations.Errors
{
    public class ApiValidations:ApiResponease
    {
        public List<string> Details { get; set; }

        public ApiValidations():base(400)
        {
            Details= new List<string>();    
        }
    }
}
