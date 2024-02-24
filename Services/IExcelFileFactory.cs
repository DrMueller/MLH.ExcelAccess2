using MLH.ExcelAccess2.Models;

namespace MLH.ExcelAccess2.Services
{
    public interface IExcelFileFactory
    {
        ExcelFile Create<T>(
            string workbookName,
            IReadOnlyCollection<T> entries, IReadOnlyCollection<ExcelColumnConfiguration<T>> configs);
    }
}