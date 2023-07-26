using Microsoft.AspNetCore.Mvc;
using SinafApi.Models;

namespace SinafApi
{
    [ApiController]
    [Route("[controller]")]
    public class BoletoController : ControllerBase
    {
        private readonly IRepository _repo;
        public BoletoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var myResult = await _repo.GetAllBoletoAsynch();
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{boletoId}")]
        public async Task<IActionResult> GetByCnpj(int boletoId)
        {
            try
            {
                var myResult = await _repo.GetBoletoAsynchById(boletoId);
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Boleto boleto)  
        {
            try
            {   
                _repo.CreateData(boleto);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(boleto);
                }
                return BadRequest("Dont expectative errors...!");
            }
            catch (System.Exception ex)
            {
                return BadRequest("Found errors => " + ex.Message);
            }
        }

        [HttpPut("{boletoId}")]
        public async Task<IActionResult> Put(int boletoId, Boleto boleto)
        {
            try
            {
                var boletoModel = await _repo.GetBoletoAsynchById(boletoId);
                if (boletoModel == null) return NotFound("Boleto não encontrado !!!");

                _repo.UpdateData(boleto);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(boleto);
                }
            }
            catch (System.Exception ex)

            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Bad Request Error !!!");
        }

        [HttpDelete("{boletoId}")]
        public async Task<IActionResult> Delete(int boletoId)
        {
            try
            {
                var boletoModel = await _repo.GetBoletoAsynchById(boletoId);
                if (boletoModel == null) return NotFound();

                _repo.DeleteData(boletoModel);

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