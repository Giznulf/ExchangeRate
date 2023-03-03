using Microsoft.AspNetCore.Mvc;
using ExchangeRate.Models;
using X.PagedList;

namespace ExchangeRate.Controllers
{
    public class CurrenciesController : Controller
    {
        private static CurrenciesFromNetwork currenciesFromNetwork = new ();

        private readonly Task<Currencies> currencie = currenciesFromNetwork.GetData();

        
        public IActionResult Currencies(int? page)
        {
            List<Valute> _currencie = new();

            foreach (var valute in currencie.Result.Valute)
            {
                _currencie.Add(valute.Value);
            }

			int pageSize = 3;
			int pageNumber = page ?? 1;
			return View(_currencie.ToPagedList(pageNumber, pageSize));

		}

        [HttpGet("currency/{id}")]
        public IActionResult Currency(string id)
        {
            

            Valute _valute = null;

            foreach (var valute in currencie.Result.Valute)
            {
                if(id == valute.Value.ID)
                {
                    _valute = valute.Value;
                }
            }

            return View(_valute);

        }
    }

    public class CurrenciesFromNetwork
    {
        static readonly HttpClient httpClient = new();

        public  Task<Currencies> GetData()
        {
            return httpClient.GetFromJsonAsync<Currencies>("https://www.cbr-xml-daily.ru/daily_json.js");
        }
    }
}
