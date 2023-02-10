using CsvHelper.Configuration.Attributes;

namespace Automacao.Core
{
    public class HibridToManual
    {
        [Name("command")]
        public string Command { get; set; } = string.Empty;
        [Name("schedule")]
        public string Schedule { get; set; } = string.Empty;
        [Name("activity")]
        public string Activity { get; set; } = string.Empty;
    }
}
