using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Automacao.Infra.Services
{
    public class CsvInfra
    {
        private static string DocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

        private static readonly CsvConfiguration Config = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
            HeaderValidated = args =>
            {

            },
            MissingFieldFound = null,
            TrimOptions = TrimOptions.Trim,
            Delimiter = ";",
        };

        public List<T> OpenAndRead<T>(string path) where T : class
        {
            return GetRecords<T>(path).ToList();
        }

        private IEnumerable<T> GetRecords<T>(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>();
            }
        }

        public static void SaveData<T>(List<T> records, string environmentName, string fileName, string toppingCode = "C")
        {
            var fullPath = $@"{DocumentsPath}\Automacao\{environmentName}\{fileName}";

            using (var writer = new StreamWriter(fullPath))
            using (var csv = new CsvWriter(writer, Config))
            {
                csv.WriteRecords(records);
            }

            AddToppingCode(toppingCode, fullPath);
        }

        public static void AddToppingCode(string toppingCode, string path)
        {
            string tempfile = Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(path))
            {
                writer.WriteLine(toppingCode);

                while (!reader.EndOfStream)
                    writer.WriteLine(reader.ReadLine());
            }

            File.Copy(tempfile, path, true);
            File.Delete(tempfile);
        }
    }
}
