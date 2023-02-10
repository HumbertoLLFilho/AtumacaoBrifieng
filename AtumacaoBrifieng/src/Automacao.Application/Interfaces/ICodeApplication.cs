using Automacao.Core;

namespace Automacao.Application.Interfaces
{
    public interface ICodeApplication
    {
        List<Code> Get();
        Code GetByID(Guid id);
        Code GetByIntegrationID(string integrationID);

        Code Add();
        Code Update(Code code);
        bool Delete();
    }
}
