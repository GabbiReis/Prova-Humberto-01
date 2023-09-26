using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PapaiNoel.Models;

namespace PapaiNoel.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CartinhaPapaiNoelController : ControllerBase
    {
        private readonly string _CartinhaNoel;

        public CartinhaPapaiNoelController()
        {
            _CartinhaNoel= Path.Combine(Directory.GetCurrentDirectory(), "Data", "Cartinha.json");
        }

        #region Operaçoes arquivo

        private List<DadosCartinhas> LerCartaDoArquivo()
        {
            if (!System.IO.File.Exists(_CartinhaNoel))
            {
                return new List<DadosCartinhas>();
            }

            string json = System.IO.File.ReadAllText(_CartinhaNoel);
            return JsonConvert.DeserializeObject<List<DadosCartinhas>>(json);
        }

        private void EscreverCartasNoArquivo(List<DadosCartinhas> cartas)
        {
            string json = JsonConvert.SerializeObject(cartas);
            System.IO.File.WriteAllText(_CartinhaNoel, json);
        }

        #endregion

        #region POST

        [HttpPost]
        public IActionResult Post(DadosCartinhas dadosCartinhas)
        {

            var CartasRealizadas = LerCartaDoArquivo();

            CartasRealizadas.Add(dadosCartinhas);

            EscreverCartasNoArquivo(CartasRealizadas);

            return Ok("Carta registrada com sucesso");
        }

        #endregion

        #region GET 

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(LerCartaDoArquivo());
        }

        #endregion
    }
}
   
