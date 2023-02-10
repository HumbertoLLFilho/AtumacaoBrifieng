namespace Automacao.Core
{
    public class Code : BaseEntity
    {
        public string IntegrationID { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Order { get; set; }
        public string Manual { get; set; } = string.Empty;
        public string Hibrid { get; set; } = string.Empty;
    }
}
