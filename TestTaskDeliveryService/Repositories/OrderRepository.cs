using Newtonsoft.Json;
using TestTaskDeliveryService.Models;
using Formatting = System.Xml.Formatting;

namespace TestTaskDeliveryService.Repositories;

public class OrderRepository
{
    private const string FILE_PATH = "orders.csv";
    List<Order> orders = new ();
    public List<Order> GetAllOrders()
    {
        try
        {
            using (var reader = new StreamReader(FILE_PATH))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Log($"Чтение строки: {line}");

                    var values = line.Split(',');

                  
                    if (values.Length != 5)
                    {
                        Log($"Некорректная строка: {line}"); 
                        continue; 
                    }

                   
                    if (double.TryParse(values[1], out double weightKg) && 
                        double.TryParse(values[2], out double weightG) &&  
                        DateTime.TryParse(values[4], out DateTime deliveryTime)) 
                    {
                        double totalWeight = weightKg + (weightG / 100); 

                        orders.Add(new Order
                        {
                            Id = values[0],
                            Weight = totalWeight,
                            District = values[3],
                            DeliveryTime = deliveryTime
                        });
                    }
                    else
                    {
                        Log($"Ошибка парсинга для строки: {line}"); 
                    }
                }
            }

            Log($"Завершено чтение. Обработано заказов: {orders.Count}");
        }
        catch (Exception ex)
        {
            Log($"Ошибка при чтении заказов: {ex.Message}");
        }

        return orders;
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