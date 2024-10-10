using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Implementation;
using WebApi.Interface;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivoController : ControllerBase
    {
        private readonly ICultivoService _ICultivoService;

        public CultivoController(ICultivoService cultivoService)
        {
            _ICultivoService = cultivoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CultivoEntities>> GetAll()
        {
            var cultivos = _ICultivoService.GetAll();
            if (cultivos == null)
            {
                return NotFound();
            }
            return Ok(cultivos);

        }

        [HttpGet("{id}")]
        public ActionResult<CultivoEntities> GetByID(int id)
        {
            var cultivo = _ICultivoService.GetById(id);
            if (cultivo == null) return NotFound();
            return Ok(cultivo);
        }

        [HttpPost]
        public ActionResult Add(CultivoEntities cultivo)
        {
            _ICultivoService.Add(cultivo);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CultivoEntities cultivo)
        {
            var find = _ICultivoService.GetById(id);
            if (find == null) return NotFound();
            cultivo.Id = id;
            _ICultivoService.Update(cultivo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var find = _ICultivoService.GetById(id);
            if (find == null) return NotFound();
            _ICultivoService.Delete(id);
            return Ok();
        }
    }
}
