namespace Automacao.Core
{
    public class Assignment : BaseEntity
    {
        public string InternalID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
