namespace Automacao.Core
{
    public class Environment : BaseEntity
    {
        public Environment()
        {

        }

        public string InternalID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Code> Codes { get; set; } = new();
        //public List<User> Users { get; set; }
        //public List<Location> Locations { get; set; }
    }
}
