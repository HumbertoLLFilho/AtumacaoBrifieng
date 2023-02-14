using Automacao.Application.Interfaces;
using Automacao.Domain.Services;
using Automacao.Infra.Services;

namespace Automacao.Application.Services
{
    public class AssignmentApplication : IAssignmentApplication
    {
        public void HibridToManual(List<string> internalIDs, Core.Environment environment)
        {
            var results = AssignmentService.HibridToManual(internalIDs, environment.Codes);

            CsvInfra.SaveData(results, environment.Name, "AAG_HIBRID-TO-MANUAL-HUMBERTO_V2.csv");
        }
    }
}
