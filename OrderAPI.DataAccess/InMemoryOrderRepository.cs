using OrderAPI.Business.Interfaces;
using OrderAPI.Domain;

namespace OrderAPI.DataAccess;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();
    private int _nextId = 1;

    public List<Order> GetAll() => _orders;

    public Order? GetById(int id) =>
        _orders.FirstOrDefault(o => o.Id == id);

    public Order Add(Order order)
    {
        order.Id = _nextId++;
        _orders.Add(order);
        return order;
    }
}