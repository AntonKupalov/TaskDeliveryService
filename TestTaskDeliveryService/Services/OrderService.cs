using TestTaskDeliveryService.Models;

namespace TestTaskDeliveryService.Services;

public class OrderService
{
    public List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryTime)
    {
        var endTime = firstDeliveryTime.AddMinutes(30);
        var filterOrders= orders
            .Where(o => o.District.Equals(district, StringComparison.OrdinalIgnoreCase) &&
                        o.DeliveryTime >= firstDeliveryTime && 
                        o.DeliveryTime <= endTime)
            .ToList();
        
        Log($"Отфильтрованные заказы для района '{district}': найдено {filterOrders.Count} между {firstDeliveryTime} и {endTime}.");
        return filterOrders;
    }
    
    private void Log(string message)
    {
        string logFilePath = "Log.txt";
        using (var writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}