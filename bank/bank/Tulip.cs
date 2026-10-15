/// <summary>
/// Тюльпан — не ароматный цветок.
/// </summary>
public class Tulip : Flower
{
    /// <summary>
    /// Длина стебля.
    /// </summary>
    public int StemLength { get; set; }

    /// <summary>
    /// Длинный ли стебель (вычисляемое свойство).
    /// </summary>
    public bool IsLong => StemLength > 30;

    /// <summary>
    /// Основной конструктор.
    /// </summary>
    public Tulip(int id, string name, decimal price, int stemLength)
        : base(id, name, price)
    {
        StemLength = stemLength;
    }

    /// <summary>
    /// Конструктор только с именем.
    /// </summary>
    public Tulip(string name) : this(0, name, 0, 0)
    {
    }

    /// <summary>
    /// Представить тюльпан.
    /// </summary>
    public override void Present()
    {
        Console.WriteLine($"{Name} presented.");
    }

    /// <summary>
    /// Строковое представление тюльпана.
    /// </summary>
    public override string ToString()
    {
        return $"[Tulip] {Name}, {Price}, color: {Color}, stem: {StemLength}";
    }
}