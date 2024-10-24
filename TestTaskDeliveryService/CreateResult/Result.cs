using System.Globalization;
using TestTaskDeliveryService.Models;

namespace TestTaskDeliveryService.CreateResult;

public class Result
{
    public void Create(List<Order> filterOrders)
    {
        string filePath = "result.csv";

        string[] csvHeader = { "OrderId", "Weight", "District", "DeliveryTime" };

        List<Order> orders = new List<Order>();
        foreach (var order in filterOrders)
        {
           orders.Add(order);
        }
        
        try
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(string.Join(",", csvHeader));
                
                foreach (var row in orders)
                {
                    writer.WriteLine($"{row.Id},{row.Weight:F2},{row.District},{row.DeliveryTime}");
                }
            }

            Log($"Файл {filePath} успешно создан.");
        }
        catch (Exception ex)
        {
            Log($"Ошибка при создании файла: {ex.Message}");
        }
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