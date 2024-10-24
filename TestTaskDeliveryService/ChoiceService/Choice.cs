using System.Globalization;

namespace TestTaskDeliveryService.ChoiceService;

public class Choice
{
    private void Log(string message)
    {
        string logFilePath = "Log.txt";
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }

    public DateTime ChooseDate()
    {
        Console.WriteLine("Введите дату рождения в формате гггг-ММ-дд чч:мм:сс:");
        Console.WriteLine("Пример: 2024-10-23 14:15:00");

        while (true)
        {
            var dateInput = Console.ReadLine();
            Log($"Пользователь ввел: {dateInput}");

            if (DateTime.TryParseExact(dateInput, "yyyy-MM-dd HH:mm:ss", 
                    System.Globalization.CultureInfo.InvariantCulture, 
                    System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                if (date <= DateTime.Now)
                {
                    Log($"Введенная дата: {date} (корректная)");
                    return date;
                }
                else
                {
                    Log($"Ошибка: дата {date} в будущем");
                    Console.WriteLine("Дата не должна быть в будущем. Попробуйте снова!");
                }
            }
            else
            {
                Log($"Ошибка: неверный формат даты '{dateInput}'");
                Console.WriteLine("Неверно введенные данные. Пожалуйста, используйте формат гггг-ММ-дд чч:мм:сс.");
            }
        }
    }

    public  string ChooseRegion()
    {
        Console.WriteLine("Выберите район:");
        Console.WriteLine("1-Central District");
        Console.WriteLine("2-North District");
        Console.WriteLine("3-East District");
        Console.WriteLine("4-South District");
        Console.WriteLine("5-West District");

       
        while (true)
        {
            var choise = Convert.ToInt32(Console.ReadLine());
            Log($"Пользователь ввел: {choise}");
            if (choise > 5 || choise <= 0)
            {
                Log($"Ошибка:некоректный ввод данных {choise}");
                Console.WriteLine("Неверно введенные данные.Попробуйте снова!");
            }
            switch (choise)
            {
                case 1:
                    Log($"Введенные данные: {choise} (корректные)");
                    return "Central District";
                    break;
                case 2:
                    Log($"Введенные данные: {choise} (корректные)");
                    return "North District";
                    break;
                case 3:
                    Log($"Введенные данные: {choise} (корректные)");
                    return "East District";
                    break;
                case 4:
                    Log($"Введенные данные: {choise} (корректные)");
                    return "South District";
                    break;
                case 5:
                    Log($"Введенные данные: {choise} (корректные)");
                    return "West District";
                    break;
            }
        }
    }
}