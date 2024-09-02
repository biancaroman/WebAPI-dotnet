using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json.Linq;
using cp_api.Model;

namespace cp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase, IExchangeController
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://v6.exchangerate-api.com/v6/de57eae077d496d8b855b3e3/latest/USD";
 
        public ExchangeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Recupera a taxa de câmbio atual do Dólar Americano (USD) para o Real Brasileiro (BRL).
        /// </summary>
        /// <returns>Retorna a taxa de câmbio atual do USD para BRL.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Recupera a taxa de câmbio atual do USD para BRL.", Description = "Este endpoint retorna a taxa de câmbio atual do Dólar Americano (USD) para o Real Brasileiro (BRL).")]
        public async Task<JsonResult> GetExchangeRate()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);
 
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseData);
                    var exchangeRate = json["conversion_rates"]?["BRL"]?.Value<double>();
 
                    if (exchangeRate.HasValue)
                    {
                        var valor = new ConversionRate
                        {
                            BRL = exchangeRate.Value
                        };

                        var result = new JsonResult(new
                        {
                            CurrencyPair = "USD/BRL",
                            Rate = valor.BRL,
                            Date = DateTime.Now
                        