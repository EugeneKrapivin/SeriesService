using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using SeriesService.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SeriesService.SeriesApi.Controllers
{
    [Route("api/series")]
    public class SeriesController : Controller
    {
        private readonly ISeriesLogic _seriesLogic;
        private readonly ILogger _logger;

        public SeriesController(ISeriesLogic seriesLogic, ILogger<SeriesController> logger)
        {
            if (seriesLogic == null) throw new ArgumentNullException(nameof(seriesLogic));
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _seriesLogic = seriesLogic;
            _logger = logger;
        }

        [HttpGet, Route("{series}")]
        public async Task<IActionResult> GetSeriesElement(string series, int? n = null)
        {
            if (n == null)
            {
                var message = "Must pass integer 'n' value as query parameter";
                _logger?.LogError(message);
                return new BadRequestObjectResult(message);
            }
            try
            {
                return Json(new { series, index = n, result = await _seriesLogic.Evalute(series, n.Value) });
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSeriesEvaluators()
        {
            try
            {
                return Json(new { series = await _seriesLogic.GetSeriesEvaluators() });
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
