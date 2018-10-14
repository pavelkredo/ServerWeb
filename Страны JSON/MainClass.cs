using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Страны_JSON
{
    internal class MainClass
    {
        private const string pathJsonFile = "americas.json";

        private static void Main()
        {
            // Создаем поток для чтения файла и считываем файл в одну строку
            var streamReader = new StreamReader(pathJsonFile);
            var json = streamReader.ReadToEnd();

            // Десереализуем JSON, используя класс Country
            var countries = JsonConvert.DeserializeObject<List<Country>>(json);

            // Вычисляем через LINQ-выражение сумму численностей населения всех стран
            var totalPopulationCount = countries.Select(country => country.Population).Sum();
            Console.WriteLine("Суммарная численность населения по странам: " + totalPopulationCount);

            // Создаем список имен валют
            var currenciesName = new List<string>();

            // Проходим по странам и валютам, ими используемыми
            foreach (var country in countries)
            {
                foreach (var currency in country.Currencies)
                {
                    // Если в списке имен валют нет валют данной страны, то добавляем
                    if (!currenciesName.Contains(currency.Name))
                    {
                        currenciesName.Add(currency.Name);
                    }
                }
            }

            // Выводим список валют в консоль
            foreach (var currencyName in currenciesName)
            {
                Console.WriteLine(currencyName);
            }
        }
    }
}