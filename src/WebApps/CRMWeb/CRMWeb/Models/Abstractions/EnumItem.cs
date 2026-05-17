namespace CRMWeb.Models.Abstractions;

public class EnumItem<T>
{
    public T Value { get; set; } = default!;
    public string Text { get; set; } = string.Empty;
}
