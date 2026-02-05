namespace OrderAPI.Web.DTOs;

public class CreateOrderRequest
{
    public string CustomerName { get; set; } = "";
    public decimal TotalAmount { get; set; }
}