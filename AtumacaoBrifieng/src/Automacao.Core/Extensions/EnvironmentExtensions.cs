using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Automacao.Core.Extensions
{
    public static class EnvironmentExtensions
    {
        private static readonly CsvConfiguration Config = new (CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
            HeaderValidated = args =>
            {
                
            },
            MissingFieldFound = null,
            TrimOptions = TrimOptions.Trim,
            Delimiter = ";",
        };


        public static Environment AddCodes(this Environment environment)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            var path = $@"{documentsPath}\Automacao\{environment.Name}\Codes.csv";
            
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, Config))
            {
                environment.Codes.AddRange(csv.GetRecords<Code>());
            }

            return environment;
        }
    }
}
