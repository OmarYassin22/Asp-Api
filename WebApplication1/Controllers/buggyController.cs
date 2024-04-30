using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Talabat.presentaion.Controllers;
using Talabat.presentations.Errors;
using Talabat.Repos.Data.Contexts;

namespace Talabat.presentations.Controllers
{

    public class buggyController : BaseAPIController
    {
        private readonly StoreDbContext _context;

        public buggyController(StoreDbContext context)
        {
            _context = context;
        }



        [HttpGet("404")]// api/Errors/404
        public ActionResult GetNotFound()
        {
            var pro = _context.Products.Find(1000);
            if (pro == null)
            {
                var response = new ApiResponease(404, "Not Found");
               
                return NotFound(response );
            }
            return Ok(pro);
        }
        [HttpGet("400")]
        public ActionResult GetBadRequest()
        { return BadRequest(new ApiResponease(400).ToString()); }
        [HttpGet("400/{id}")]
        public ActionResult GetBadRequest(int? id)
        { return Ok(); }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {

            var pro = _context.Products.Find(1000);
            var result = pro.ToString();
            return Ok(result);
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnAuthorized()
        {
            return Unauthorized(new ApiResponease(401));
        }

    }
}
