using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET: api/order
    [HttpGet]
    public IEnumerable<OrderModel> Get()
    {
        return _orderService.List();
    }

    // GET api/order/1
    [HttpGet("{id}")]
    public OrderModel Get(int id)
    {
        return _orderService.Get(id);
    }

    // POST api/order
    [HttpPost]
    public int Post([FromBody] OrderModel model)
    {
        return _orderService.Add(model);
    }

    // PUT api/order
    [HttpPut]
    public int Put([FromBody] OrderModel model)
    {
        return _orderService.Update(model);
    }

    // DELETE api/order/1
    [HttpDelete("{id}")]
    public Task Delete(int id)
    {
        return _orderService.Delete(id);
    }
}
