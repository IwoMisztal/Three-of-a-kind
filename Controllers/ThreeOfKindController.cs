using LookingForThree.Models;
using LookingForThree.Services;
using Microsoft.AspNetCore.Mvc;

namespace LookingForThree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThreeOfKindController : Controller
    {

        private readonly ThreeOfKindSevice _threeOfKindSevice;

        public ThreeOfKindController(ThreeOfKindSevice threeOfKindSevice)
        {
            _threeOfKindSevice = threeOfKindSevice;
        }

        [HttpPost]
        [Route("/[controller]")]
        public IActionResult ProccessNumbers(string[] numbersToProcess)
        {
            List<int> processedNumbers;
            try
            {
                processedNumbers = _threeOfKindSevice.ProcessNumbers(numbersToProcess);
            } catch(Models.FormatException ex)
            {
                return base.StatusCode(500, ex.Message);
            }
            return Json(processedNumbers);
        }
    }
}