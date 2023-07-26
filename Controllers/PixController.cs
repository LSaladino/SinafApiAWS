using Microsoft.AspNetCore.Mvc;
using SinafApi.Models;

namespace SinafApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixController : ControllerBase
    {

        private readonly IRepository _repo;
        public PixController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var myResult = await _repo.GetAllPixAsynch();
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

         [HttpGet("{pixId}")]
        public async Task<IActionResult> GetById(int pixId)
        {
            try
            {
                var myResult = await _repo.GetPixAsynchById(pixId);
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pix pix)
        {
            try
            {
                _repo.CreateData(pix);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(pix);
                }
                return BadRequest("Dont expectative errors...!");
            }
            catch (System.Exception ex)
            {
                return BadRequest("Found errors => " + ex.Message);
            }
        }

        [HttpPut("{pixId}")]
        public async Task<IActionResult> Put(int pixId, Pix pix)
        {
            try
            {
                var pixModel = await _repo.GetPixAsynchById(pixId);
                if (pixModel == null) return NotFound("Boleto não encontrado !!!");

                _repo.UpdateData(pix);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(pix);
                }
            }
            catch (System.Exception ex)

            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Bad Request Error !!!");
        }

        [HttpDelete("{pixId}")]
        public async Task<IActionResult> Delete(int pixId)
        {
            try
            {
                var pixModel = await _repo.GetPixAsynchById(pixId);
                if (pixModel == null) return NotFound();

                _repo.DeleteData(pixModel);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(new { mensagem = "Deleted with Success !!" });
                }
            }
            catch (System.Exception ex)

            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Bad Request Error !!!");
        }
    }
}