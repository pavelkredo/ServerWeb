using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace Excel
{
    internal class MainClass
    {
        private static void Main()
        {
            try
            {
                // Задаем файл для работы с таблицей Excel
                var workbook = new XLWorkbook();
                var worksheet = workbook.AddWorksheet("Список людей");

                // Задаем номер текущей строки
                var currentRow = 1;

                // Задаем шапку таблицы
                worksheet.Cell("A" + currentRow).Value = "Возраст";
                worksheet.Cell("B" + currentRow).Value = "Имя";
                worksheet.Cell("C" + currentRow).Value = "Фамилия";
                worksheet.Cell("D" + currentRow).Value = "Номер телефона";

                // Выставим ширину ячейки для имени, фамилии и номера телефона
                worksheet.Column("B").Width = 15;
                worksheet.Column("C").Width = 15;
                worksheet.Column("D").Width = 20;

                // Инкрементируем переменную перехода на следующую строку
                currentRow++;

                // Создаем список объектов класса Person
                var personList = new List<Person>
                {
                    new Person(27, "Василий", "Горбунов", "+7 913 422-47-02"),
                    new Person(44, "Иван", "Мамонов", "+7 999 742-86-34"),
                    new Person(34, "Ольга", "Пушкина", "+7 923 122-44-22")
                };

                // Заполняем таблицу данными
                foreach (var person in personList)
                {
                    worksheet.Cell("A" + currentRow).Value = person.Age;
                    worksheet.Cell("B" + currentRow).Value = person.Name;
                    worksheet.Cell("C" + currentRow).Value = person.Surname;
                    worksheet.Cell("D" + currentRow).Value = person.Phone;

                    // Инкрементируем переменную перехода на следующую строку
                    currentRow++;
                }

                // Сохраняем в Excel файл
                workbook.SaveAs("PersonTable.xlsx");

                // Выводим сообщение в случае успешного прохождения блока try до конца
                Console.WriteLine("Файл успешно сохранен.");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ошибка при работе с файлом: " + exception.Message);
            }
        }
    }
}