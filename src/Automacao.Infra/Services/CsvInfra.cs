using System.Globalization;
using CsvHelper;

namespace Automacao.Infra.Services
{
    public class CsvInfra
    {
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

        public static void SaveData<T>(List<T> records, string path, string toppingCode = "C")
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }

            AddToppingCode(toppingCode, path);
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
