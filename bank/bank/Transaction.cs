
namespace bank;

/// <summary>
/// Тип данных который запрещает менять состояние обьекта
/// </summary>
/// <param name="Amount">сумма транзакций</param>
/// <param name="Date">дата транзакций</param>
/// <param name="Note">заметка транзакций</param>

internal record Transaction(decimal Amount, DateTime Date, string Note);
