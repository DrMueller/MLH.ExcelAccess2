using ClosedXML.Excel;
using MLH.ExcelAccess2.Models;

namespace MLH.ExcelAccess2.Services
{
    public interface IExcelColumnConfigurationBuilder<T>
    {
        ExcelColumnConfiguration<T> Build();
        IExcelColumnConfigurationBuilder<T> WithHeader(string header);

        IExcelColumnConfigurationBuilder<T> WithStyle(Action<IXLStyle> styleConfig);

        IExcelColumnConfigurationBuilder<T> WithValueSetter(Action<T, IXLCell> selector);
    }
}