using Automacao.Application.Interfaces;
using Automacao.Core.Extensions;

namespace Automacao.Application.Services
{
    public class EnvironmentApplication : IEnvironmentApplication
    {
        public List<Core.Environment> Get()
        {
            return new List<Core.Environment>()
            {
                new Core.Environment()
                {
                    Name = "Big",
                    InternalID = "pmbg01",
                }.AddCodes()
            };
        }

        public Core.Environment? GetByInternalID(string internalID) => Get().FirstOrDefault(e => e.InternalID == internalID);
    }
}
