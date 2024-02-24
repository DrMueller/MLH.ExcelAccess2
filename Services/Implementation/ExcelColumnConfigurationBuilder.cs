using ClosedXML.Excel;
using MLH.ExcelAccess2.Models;

namespace MLH.ExcelAccess2.Services.Implementation
{
    public class ExcelColumnConfigurationBuilder<T> : IExcelColumnConfigurationBuilder<T>
    {
        private string _header = default!;
        private Action<T, IXLCell> _selector = default!;
        private Action<IXLStyle>? _styleConfig;

        public ExcelColumnConfiguration<T> Build()
        {
            return new ExcelColumnConfiguration<T>(_selector, _header, _styleConfig);
        }

        public IExcelColumnConfigurationBuilder<T> WithHeader(string header)
        {
            _header = header;

            return this;
        }

        public IExcelColumnConfigurationBuilder<T> WithStyle(Action<IXLStyle> styleConfig)
        {
            _styleConfig = styleConfig;

            return this;
        }

        public IExcelColumnConfigurationBuilder<T> WithValueSetter(Action<T, IXLCell> selector)
        {
            _selector = selector;

            return this;
        }
    }
}