namespace Automacao.Core
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public bool IsDelete { get; set; }
        
        public DateTime? CreatedAt { get;set; }
        public DateTime? UpdatedAt { get;set; }
        public DateTime? DeletedAt { get; set; }

    }
}
