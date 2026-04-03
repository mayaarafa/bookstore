using Bookstore.Models;
using Humanizer;

namespace Bookstore.Services;

public class OrderState
{
    public Order Order { get; set; } = new Order();

    public event Action OnChange;

    public OrderState()
    {
        Order.OrderItems = new List<OrderItem>();
    }

    public void AddToCart(OrderItem item)
    {
        Order.OrderItems.Add(item);
        OnChange?.Invoke();
    }

    public void RemoveFromCart(OrderItem item)
    {
        Order.OrderItems.Remove(item);
        OnChange?.Invoke();
    }

    public void ClearOrder()
    {
        Order = new Order();
        OnChange?.Invoke();
    }
}