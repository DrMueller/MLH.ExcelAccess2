using Lamar;
using MLH.ExcelAccess2.Models;
using MLH.ExcelAccess2.Services;
using MLH.ExcelAccess2.Test;

namespace MLH.ExcelAccess2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new Container(f =>
            {
                f.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<Program>();
                    scanner.WithDefaultConventions();
                });
            });


            var individuals = new List<Individual>
            {
                new Individual
                {
                    DateOfBirth = new DateTime(1986, 12, 29),
                    Email = "Test@gmx.ch",
                    FirstName = "John",
                    LastName = "Doe",
                    Height = 185
                },
                new Individual
                {
                    DateOfBirth = new DateTime(2001, 2, 3),
                    Email = "Hello@gmx.ch",
                    FirstName = "Matthias",
                    LastName = "Montreal",
                    Height = 13
                },
            };

            var builderFactory = container.GetInstance<IExcelColumnConfigurationBuilderFactory>();

            var emailConfig =
                builderFactory.StartBuilding<Individual>()
                    .WithHeader("E-Mail")
                    .WithValueSetter((f, c) => c.SetValue(f.Email))
                    .Build();

            var birthdayConfig = builderFactory.StartBuilding<Individual>()
                .WithHeader("Date of Birth")
                .WithValueSetter((f, c) => c.SetValue(f.DateOfBirth))
                .WithStyle(f => f.DateFormat.Format = "dd.MM.yyyy")
                .Build();

            var heightConfig =
                builderFactory.StartBuilding<Individual>()
                    .WithHeader("Height")
                    .WithValueSetter((f, c) => c.SetValue(f.Height))
                    .WithStyle(f => f.NumberFormat.Format = "0.00")
                    .Build();

            var configs = new List<ExcelColumnConfiguration<Individual>>
            {
                emailConfig,
                birthdayConfig,
                heightConfig
            };

            var excelPath = @"C:\Users\matthias.mueller\Desktop\Test.xlsx";

            var fileFactory = container.GetInstance<IExcelFileFactory>();

            var excelFile = fileFactory.Create("Test", individuals, configs);

            File.WriteAllBytes(excelPath, excelFile.Data);
        }
    }
}