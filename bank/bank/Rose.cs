/// <summary>
/// Роза — ароматный цветок.
/// </summary>
public class Rose : Flower, IFragrant
{
    /// <summary>
    /// Количество шипов.
    /// </summary>
    public int ThornCount { get; set; }

    /// <summary>
    /// Колючая ли роза (вычисляемое свойство).
    /// </summary>
    public bool IsPrickly => ThornCount > 0;

    /// <summary>
    /// Основной конструктор.
    /// </summary>
    public Rose(int id, string name, decimal price, int thornCount)
        : base(id, name, price)
    {
        ThornCount = thornCount;
    }

    /// <summary>
    /// Конструктор только с именем.
    /// </summary>
    public Rose(string name) : this(0, name, 0, 0)
    {
    }

    /// <summary>
    /// Представить розу.
    /// </summary>
    public override void Present()
    {
        Console.WriteLine($"{Name} presented.");
    }

    /// <summary>
    /// Издать аромат розы.
    /// </summary>
    public void Smell()
    {
        Console.WriteLine($"{Name} smells sweet.");
    }

    /// <summary>
    /// Строковое представление розы.
    /// </summary>
    public override string ToString()
    {
        return $"[Rose] {Name}, {Price}, color: {Color}";
    }
}