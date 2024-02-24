namespace MLH.ExcelAccess2.Services.Implementation
{
    public class ExcelColumnConfigurationBuilderFactory : IExcelColumnConfigurationBuilderFactory
    {
        public IExcelColumnConfigurationBuilder<T> StartBuilding<T>()
        {
            return new ExcelColumnConfigurationBuilder<T>();
        }
    }
}