using Microsoft.AspNetCore.Mvc;
using SinafApi.Models;

namespace SinafApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeioPagamentoController : ControllerBase
    {

        private readonly IRepository _repo;
        public MeioPagamentoController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var myResult = await _repo.GetAllMeioPagAsynch();
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

         [HttpGet("{meiopagId}")]
        public async Task<IActionResult> GetById(int meiopagId)
        {
            try
            {
                var myResult = await _repo.GetMeioPagAsynchById(meiopagId);
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MeioPagamento meioPagamento)
        {
            try
            {
                _repo.CreateData(meioPagamento);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(meioPagamento);
                }
                return BadRequest("Dont expectative errors...!");
            }
            catch (System.Exception ex)
            {
                return BadRequest("Found errors => " + ex.Message);
            }
        }

        [HttpPut("{meiopagId}")]
        public async Task<IActionResult> Put(int meiopagId, MeioPagamento meioPagamento)
        {
            try
            {
                var meioPagModel = await _repo.GetMeioPagAsynchById(meiopagId);
                if (meioPagModel == null) return NotFound("Boleto não encontrado !!!");

                _repo.UpdateData(meioPagamento);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(meioPagamento);
                }
            }
            catch (System.Exception ex)

            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Bad Request Error !!!");
        }

        [HttpDelete("{meiopagId}")]
        public async Task<IActionResult> Delete(int meiopagId)
        {
            try
            {
                var meioPagModel = await _repo.GetMeioPagAsynchById(meiopagId);
                if (meioPagModel == null) return NotFound();

                _repo.DeleteData(meioPagModel);

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