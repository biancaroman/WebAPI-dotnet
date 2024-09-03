using Swashbuckle.AspNetCore.Annotations;

namespace cp_api.Model
{
    public class ConversionRate : IConversionRate
    {

    [SwaggerSchema(Title = "Taxa de Câmbio BRL", Description = "Representa a taxa de câmbio atual do Dólar Americano (USD) para o Real Brasileiro (BRL).")]
    public double BRL { get; set; }
    }
}