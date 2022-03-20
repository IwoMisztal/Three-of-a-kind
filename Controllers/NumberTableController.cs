using Microsoft.AspNetCore.Mvc;

namespace LookingForThree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberTableController : Controller
    {

        private readonly ILogger<NumberTableController> _logger;

        public NumberTableController(ILogger<NumberTableController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/[controller]/proccessNumbers")]
        public IActionResult ProccessNumbers(int[] numbersToProcess)
        {
            List<int> processedNumbers;

            processedNumbers = numbersToProcess
                .Where(q => q <= 9)
                .GroupBy(q => q)
                .Where(q => q.Count() > 2)
                .Select(q => q.Key)
                .OrderByDescending(q => q)
                .ToList();
            return Json(processedNumbers);
        }
    }
}