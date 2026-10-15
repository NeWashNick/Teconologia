/// <summary>
/// Базовый абстрактный класс цветка.
/// </summary>
public abstract class Flower
{
    private int _id;

    /// <summary>
    /// Название цветка.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена цветка.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Цвет цветка (по умолчанию Red).
    /// </summary>
    public FlowerColor Color { get; set; } = FlowerColor.Red;

    /// <summary>
    /// Цена с доставкой (вычисляемое свойство).
    /// </summary>
    public decimal PriceWithDelivery => Price + 300;

    /// <summary>
    /// Конструктор с id, именем и ценой.
    /// </summary>
    public Flower(int id, string name, decimal price)
    {
        _id = id;
        Name = name;
        Price = price;
    }

    /// <summary>
    /// Конструктор только с именем (вызывает основной через this).
    /// </summary>
    public Flower(string name) : this(0, name, 0)
    {
    }

    /// <summary>
    /// Абстрактный метод представления цветка.
    /// </summary>
    public abstract void Present();
}