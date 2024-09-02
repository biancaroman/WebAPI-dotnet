using Microsoft.AspNetCore.Mvc;

namespace cp_api.Controllers
{
    public interface IExchangeController
    {
        JsonResult GetExchangeRate();
    }
}