using LookingForThree.Models;
using LookingForThree.Services;
using Microsoft.AspNetCore.Mvc;

namespace LookingForThree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberTableController : Controller
    {

        private readonly ThreeOfKindSevice _threeOfKindSevice;

        public NumberTableController(ThreeOfKindSevice threeOfKindSevice)
        {
            _threeOfKindSevice = threeOfKindSevice;
        }

        [HttpPost]
        [Route("/[controller]/proccessNumbers")]
        public IActionResult ProccessNumbers(string[] numbersToProcess)
        {
            List<int> processedNumbers;
            try
            {
                processedNumbers = _threeOfKindSevice.ProcessNumbers(numbersToProcess);
            } catch(NumberListException ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Json(processedNumbers);
        }
    }
}