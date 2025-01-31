using API_erstellen.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_erstellen.Controllers;

[ApiController]
[Route("[controller]")]
public class MedienController : ControllerBase
{
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (Data.MedienDic.Remove(id))
        {
            return NoContent();
        }
        else
        {
            return NotFound($"Signatur '{id}' nicht gefunden!");
        }
    }

    [HttpGet]
    public ActionResult<List<Medium>> Get()
    {
        return Ok(Data.MedienDic.Values.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Medium> Get(int id)
    {
        var medium = Data.GetElement(id);
        if (medium is null)
        {
            return NotFound($"Signatur '{id}' nicht gefunden!");
        }
        return Ok(medium);
    }

    [HttpPost]
    public ActionResult Post(Medium request)
    {
        var medium = Data.GetElement(request.Signatur);
        if (medium is not null)
        {
            return BadRequest($"Medium mit Signatur '{request.Signatur}' bereits vorhanden.");
        }
        Data.MedienDic.Add(request.Signatur, request);
        return CreatedAtAction(nameof(Get), new { id = request.Signatur }, request);
    }

    [HttpPut]
    public ActionResult<Medium> Put(Medium request)
    {
        var medium = Data.GetElement(request.Signatur);
        if (medium is null)
        {
            return NotFound($"Signatur '{request.Signatur}' nicht gefunden!");
        }
        Data.MedienDic[request.Signatur] = request;
        return Ok(request);
    }
}