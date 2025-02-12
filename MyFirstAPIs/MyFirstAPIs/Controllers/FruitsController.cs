using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        public List<String> fruits = new List<String>()
        {
            "Apple", "Mango", "Banana", "Oranges"
        };
        
        [HttpGet]
        public List<String> GetFruits()
        {
            return fruits;
        }

        [HttpGet("{id}")]
        public String GetFruitById(int id)
        {
            return fruits[id];
        }

        [HttpPost]
        public List<String> AddFruits([FromBody]String fruit)
        {
            fruits.Add(fruit);
            return fruits;
        }
    }
}
