using System;
using System.Collections.Generic;

/// <summary>
/// Главный класс программы.
/// </summary>
public class Program
{
    /// <summary>
    /// Точка входа.
    /// </summary>
    public static void Main()
    {
        // Полиморфная коллекция базового типа
        List<Flower> bouquet = new List<Flower>
        {
            new Rose(1, "Red Rose", 250, 12) { Color = FlowerColor.Red },
            new Tulip(2, "Holland", 150, 40) { Color = FlowerColor.Red },
            new Lily(3, "White Lily", 400, 8) { Color = FlowerColor.White }
        };

        // Перебор коллекции
        foreach (Flower flower in bouquet)
        {
            Console.WriteLine(flower);

            Console.WriteLine($"  price with delivery: {flower.PriceWithDelivery}");

            // Специфичная логика по типу
            if (flower is Rose rose)
            {
                Console.WriteLine($"  prickly: {rose.IsPrickly}");
            }
            else if (flower is Tulip tulip)
            {
                Console.WriteLine($"  long stem: {tulip.IsLong}");
            }
            else if (flower is Lily lily)
            {
                Console.WriteLine($"  big: {lily.IsBig}");
            }

            // Вызов абстрактного метода
            flower.Present();

            // Проверка интерфейса
            if (flower is IFragrant fragrant)
            {
                fragrant.Smell();
            }
            else
            {
                Console.WriteLine($"{flower.Name} cannot smell.");
            }

            Console.WriteLine();
        }
    }
}