using Microsoft.AspNetCore.Mvc;

namespace API_erstellen.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<string> testData = new List<string>(["Max", "Andreas", "Hans", "Eddy"]);

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        testData.RemoveAt(id);
        return NoContent();
    }

    [HttpGet]
    public ActionResult<List<string>> Get()
    {
        return Ok(testData);
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        if (id >= testData.Count || id < 0)
        {
            return NotFound();
        }
        return Ok(testData[id]);
    }

    [HttpPost]
    public ActionResult Post(string value)
    {
        testData.Add(value);
        return Created();
    }
}