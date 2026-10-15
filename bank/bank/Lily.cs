/// <summary>
/// Лилия — ароматный цветок.
/// </summary>
public class Lily : Flower, IFragrant
{
    /// <summary>
    /// Количество лепестков.
    /// </summary>
    public int PetalCount { get; set; }

    /// <summary>
    /// Большой ли цветок (вычисляемое свойство).
    /// </summary>
    public bool IsBig => PetalCount > 6;

    /// <summary>
    /// Основной конструктор.
    /// </summary>
    public Lily(int id, string name, decimal price, int petalCount)
        : base(id, name, price)
    {
        PetalCount = petalCount;
    }

    /// <summary>
    /// Конструктор только с именем.
    /// </summary>
    public Lily(string name) : this(0, name, 0, 0)
    {
    }

    /// <summary>
    /// Представить лилию.
    /// </summary>
    public override void Present()
    {
        Console.WriteLine($"{Name} presented.");
    }

    /// <summary>
    /// Издать аромат лилии.
    /// </summary>
    public void Smell()
    {
        Console.WriteLine($"{Name} smells fresh.");
    }

    /// <summary>
    /// Строковое представление лилии.
    /// </summary>
    public override string ToString()
    {
        return $"[Lily] {Name}, {Price}, color: {Color}, petals: {PetalCount}";
    }
}