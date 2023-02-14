namespace Automacao.Application.Interfaces
{
    public interface IAssignmentApplication
    {
        void HibridToManual(List<string> internalIDs, Core.Environment envoirment);
    }
}
