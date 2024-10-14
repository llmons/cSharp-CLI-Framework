using System.Diagnostics.CodeAnalysis;
namespace UnixLike.ColorizeConsole;
public static class AnsiConsole
{
    internal static readonly AnsiTextWriter Out = new(System.Console.Out);

    /// <summary>
    /// 是否输出前缀
    /// </summary>
    public static bool PrefixOutput
    {
        get; set;
    } = true;

    public static void WriteLine(string? text)
        => Out.WriteLine(text);


    [return: NotNullIfNotNull("value")]
    public static string? Colorize(string? value, Func<string?, string> colorizeFunc)
        => colorizeFunc(value);

    private static string? Prefix(string prefix, string? value)
        => PrefixOutput
            ? value == null
                ? prefix
                : string.Join(
                    Environment.NewLine,
                    value.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(l => prefix + l))
            : value;

    public static void WriteError(string? message) => WriteLine(Prefix("错误：", Colorize(message, x => Bold + Red + x + Reset)));
}