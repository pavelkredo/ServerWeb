using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Страны_JSON
{
    internal class MainClass
    {
        private const string pathJsonFile = "../../americas.json";

        private static void Main()
        {
            // создаем переменную строки для JSON'а
            string json;

            // создаем поток для чтения файла и считываем файл в одну строку
            using (var streamReader = new StreamReader(pathJsonFile))
            {
                json = streamReader.ReadToEnd();
            }

            // десереализуем JSON, используя класс Country
            var countries = JsonConvert.DeserializeObject<List<Country>>(json);

            // вычисляем через LINQ-выражение сумму численностей населения всех стран
            var totalPopulationCount = countries.Sum(country => country.Population);
            Console.WriteLine("Суммарная численность населения по странам: " + totalPopulationCount);
            Console.WriteLine();

            // выберем неповторяющиеся наименования используемых валют из списка стран,
            // сразу проверяя на отсутствие наименования у валюты (null)
            var currencies = countries
                .SelectMany(country => country.Currencies)
                .Select(currency => currency.Name)
                .Where(name => name != null)
                .Distinct();

            // Выводим список валют в консоль
            Console.WriteLine("Список валют:");
            foreach (var currency in currencies)
            {
                Console.WriteLine(currency);
            }
        }
    }
}