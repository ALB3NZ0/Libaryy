using System;
using System.IO;
using System.Text.Json;

namespace LibraryJson
{
    public static class Json
    {
        public static void SerializeToFile<T>(T obj, string path)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(path, jsonString);
                Console.WriteLine($"Успешная серилизация и записан в {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при серилизации и не загрузка в {path}: {ex.Message}");
            }
        }

        public static T DeserilizeFromFile<T>(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    T obj = JsonSerializer.Deserialize<T>(jsonString);
                    Console.WriteLine($"Успешная десерилизация: {path}");
                    return obj;
                }
                else
                {
                    Console.WriteLine($"Файл не найден: {path}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при десерлизации: {ex.Message}");
                return default;
            }
        }
    }
}
