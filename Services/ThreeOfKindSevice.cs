using LookingForThree.Models;

namespace LookingForThree.Services
{
    public class ThreeOfKindSevice
    {

        public List<int> ProcessNumbers(string[] numbersToProcess)
        {
            var result = new List<int>();
            result = numbersToProcess
            .Where(q => !string.IsNullOrEmpty(q))
            .Select(q => {
                int i;
                return int.TryParse(q, out i) 
                    ? i 
                    : throw new NumberListException("Invalid input format");
            })
            .Where(q => q <= 9)
            .GroupBy(q => q)
            .Where(q => q.Count() > 2)
            .Select(q => q.Key)
            .OrderByDescending(q => q)
            .ToList();

            return result;
        }
    }
}
