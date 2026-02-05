using OrderAPI.Business.Interfaces;
using OrderAPI.Domain;

namespace OrderAPI.Business.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;

    public OrderService(IOrderRepository repo)
    {
        _repo = repo;
    }

    public List<Order> GetAll() => _repo.GetAll();

    public Order? GetById(int id) => _repo.GetById(id);

    public Order CreateOrder(string customerName, decimal totalAmount)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new Exception("Customer name is required.");

        if (totalAmount <= 0)
            throw new Exception("Total amount must be positive.");

        var order = new Order
        {
            CustomerName = customerName,
            TotalAmount = totalAmount
        };

        return _repo.Add(order);
    }
}