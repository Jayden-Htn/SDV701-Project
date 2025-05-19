using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LawnmowerController : ControllerBase
{
    ILawnmowerService _lawnmowerService;

    public LawnmowerController(ILawnmowerService lawnmowerService)
    {
        _lawnmowerService = lawnmowerService;
    }

    // GET: api/lawnmower
    [HttpGet]
    public IEnumerable<LawnmowerModel> List()
    {
        return _lawnmowerService.List();
    }

    // GET api/lawnmower/1
    [HttpGet("{id}")]
    public LawnmowerModel Get(int id)
    {
        return _lawnmowerService.Get(id);
    }

    // POST api/lawnmower
    [HttpPost]
    public int Post([FromBody] LawnmowerModel model)
    {
        return _lawnmowerService.Add(model);
    }

    // PUT api/lawnmower
    [HttpPut]
    public int Put([FromBody] LawnmowerModel model)
    {
        return _lawnmowerService.Update(model);
    }

    // DELETE api/lawnmower/1
    [HttpDelete("{id}")]
    public Task Delete(int id)
    {
        return _lawnmowerService.Delete(id);
    }
}
