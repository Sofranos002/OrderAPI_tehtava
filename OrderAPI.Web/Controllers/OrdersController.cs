using Microsoft.AspNetCore.Mvc;
using OrderAPI.Business.Interfaces;
using OrderAPI.Web.DTOs;

namespace OrderAPI.Web.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = _service.GetById(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public IActionResult Create(CreateOrderRequest req)
    {
        try
        {
            var order = _service.CreateOrder(req.CustomerName, req.TotalAmount);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}