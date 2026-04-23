using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4CSharp
{
    public struct PersonStruct
    {
        public string FullName;
        public string Address;
        public string Phone;
        public int Age;

        public PersonStruct(string fullName, string address, string phone, int age)
        {
            FullName = fullName;
            Address = address;
            Phone = phone;
            Age = age;
        }

        public override string ToString()
        {
            return $"[Структура] {FullName}, {Address}, {Phone}, {Age} років";
        }
    }

    public record PersonRecord(string FullName, string Address, string Phone, int Age)
    {
        public override string ToString()
        {
            return $"[Запис] {FullName}, {Address}, {Phone}, {Age} років";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Завдання 3");

            Console.Write("Введіть кількість людей у базовому масиві: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некоректна кількість.");
                return;
            }

            PersonStruct[] structArray = new PersonStruct[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nВведення даних для людини {i + 1}:");
                Console.Write("ПІБ: ");
                string name = Console.ReadLine();
                Console.Write("Адреса: ");
                string address = Console.ReadLine();
                Console.Write("Телефон: ");
                string phone = Console.ReadLine();
                Console.Write("Вік: ");
                int age = int.Parse(Console.ReadLine());

                structArray[i] = new PersonStruct(name, address, phone, age);
            }

            var tupleArray = new (string FullName, string Address, string Phone, int Age)[n];
            PersonRecord[] recordArray = new PersonRecord[n];

            for (int i = 0; i < n; i++)
            {
                tupleArray[i] = (structArray[i].FullName, structArray[i].Address, structArray[i].Phone, structArray[i].Age);
                recordArray[i] = new PersonRecord(structArray[i].FullName, structArray[i].Address, structArray[i].Phone, structArray[i].Age);
            }

            Console.Write("\nВведіть вік для видалення з масивів: ") 
            int ageToDelete = int.Parse(Console.ReadLine());

            structArray = structArray.Where(p => p.Age != ageToDelete).ToArray();
            tupleArray = tupleArray.Where(p => p.Age != ageToDelete).ToArray();
            recordArray = recordArray.Where(p => p.Age != ageToDelete).ToArray();

            Console.WriteLine($"\nКількість елементів після видалення віку {ageToDelete}: {structArray.Length}");

            Console.Write("\nВведіть індекс елемента, після якого необхідно додати нову людину: ");
            int insertIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть дані нової людини для вставки:");
            Console.Write("ПІБ: ");
            string newName = Console.ReadLine();
            Console.Write("Адреса: ");
            string newAddress = Console.ReadLine();
            Console.Write("Телефон: ");
            string newPhone = Console.ReadLine();
            Console.Write("Вік: ");
            int newAge = int.Parse(Console.ReadLine());

            PersonStruct newStruct = new PersonStruct(newName, newAddress, newPhone, newAge);
            var newTuple = (FullName: newName, Address: newAddress, Phone: newPhone, Age: newAge);
            PersonRecord newRecord = new PersonRecord(newName, newAddress, newPhone, newAge);

            structArray = InsertAfter(structArray, insertIndex, newStruct);
            tupleArray = InsertAfter(tupleArray, insertIndex, newTuple);
            recordArray = InsertAfter(recordArray, insertIndex, newRecord);

            Console.WriteLine("\n--- Результати (Масив Структур) ---");
            foreach (var item in structArray) Console.WriteLine(item);

            Console.WriteLine("\n--- Результати (Масив Кортежів) ---");
            foreach (var item in tupleArray) Console.WriteLine($"[Кортеж] {item.FullName}, {item.Address}, {item.Phone}, {item.Age} років");

            Console.WriteLine("\n--- Результати (Масив Записів) ---");
            foreach (var item in recordArray) Console.WriteLine(item);
        }

        static T[] InsertAfter<T>(T[] array, int index, T newItem)
        {
            List<T> list = new List<T>(array);
            if (index >= 0 && index < list.Count)
            {
                list.Insert(index + 1, newItem);
            }
            else
            {
                list.Add(newItem);
            }
            return list.ToArray();
        }
    }
}