using OrderAPI.Domain;

namespace OrderAPI.Business.Interfaces;

public interface IOrderRepository
{
    List<Order> GetAll();
    Order? GetById(int id);
    Order Add(Order order);
}
