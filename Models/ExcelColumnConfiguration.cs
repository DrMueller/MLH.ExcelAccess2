using ClosedXML.Excel;

namespace MLH.ExcelAccess2.Models;

public class ExcelColumnConfiguration<T>
{
    public ExcelColumnConfiguration(
        Action<T, IXLCell> selector,
        string header,
        Action<IXLStyle>? styleConfig)
    {
        Selector = selector;
        Header = header;
        StyleConfig = styleConfig;
    }

    public string Header { get; }

    public Action<T, IXLCell> Selector { get; }
    public Action<IXLStyle>? StyleConfig { get; }
}