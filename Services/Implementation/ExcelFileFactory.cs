using ClosedXML.Excel;
using MLH.ExcelAccess2.Models;

namespace MLH.ExcelAccess2.Services.Implementation;

public class ExcelFileFactory : IExcelFileFactory
{
    public ExcelFile Create<T>(
        string workbookName,
        IReadOnlyCollection<T> entries, IReadOnlyCollection<ExcelColumnConfiguration<T>> configs)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(workbookName);

        var col = 1;

        foreach (var config in configs)
        {
            worksheet.Cell(1, col++).Value = config.Header;
        }

        var row = 2;

        foreach (var entry in entries)
        {
            col = 1;

            foreach (var config in configs)
            {
                config.StyleConfig?.Invoke(worksheet.Column(col).Style);
                var cell = worksheet.Cell(row, col++);
                config.Selector.Invoke(entry, cell);
            }

            row++;
        }

        var stream = new MemoryStream();
        workbook.SaveAs(stream);

        var result = new ExcelFile(stream.ToArray());

        return result;
    }
}