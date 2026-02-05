using OrderAPI.Domain;

namespace OrderAPI.Business.Interfaces;

public interface IOrderService
{
    List<Order> GetAll();
    Order? GetById(int id);
    Order CreateOrder(string customerName, decimal totalAmount);
}