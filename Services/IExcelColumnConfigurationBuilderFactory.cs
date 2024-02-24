namespace MLH.ExcelAccess2.Services
{
    public interface IExcelColumnConfigurationBuilderFactory
    {
        IExcelColumnConfigurationBuilder<T> StartBuilding<T>();
    }
}