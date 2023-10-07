using Api_cookies.DTO;
using Api_cookies.Models;
using Api_cookies.Models.Interface;
using Api_cookies.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api_cookies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class cookiestand : ControllerBase
    {
        private Icookiestand _service { get; set; }
        public cookiestand(Icookiestand cookieService)
        {
            _service = cookieService;
            
        }

        [HttpPost]
        public async Task<ActionResult<cookieStandDTO>> Add(CreateCookieDTO CreateNew)
        {
           await _service.Create(CreateNew);
            return Ok(CreateNew);
        }
        [HttpGet]
        public async Task<List<cookieStandDTO>> GetAllCookie()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<cookieStandDTO>> GetCookieByID(int id)
        {
          return  await _service.GetById(id);
            
        }

        [HttpDelete("{id}")]
        public async Task DeleteCookie(int id)
        {
             await _service.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCookieStand(int id, [FromBody] CreateCookieDTO stand)
        {
            var updatedCookieStand = await _service.Update(id, stand);

            if (updatedCookieStand == null)
            {
                return NotFound(); 
            }

            return Ok(updatedCookieStand);
        }



    }
}
