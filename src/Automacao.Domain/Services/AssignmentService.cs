using Automacao.Core;

namespace Automacao.Domain.Services
{
    public class AssignmentService
    {
        private readonly static List<string> ComumTerms = new List<string>()
        {
            "_CAD",
            "_LST"
        };

        public static List<HibridToManual> HibridToManual(List<string> internalIDs, List<Code> codes)
        {
            var internalCodeIDs = new List<HibridToManual>();

            foreach (var internalID in internalIDs)
            {
                var codePart = GetInternalCode(internalID);

                var code = codes.FirstOrDefault(e => e.IntegrationID.Contains(codePart));

                if (code is null)
                    Console.WriteLine("\nWARN: Codigo {0} não foi encontrado dento dos codigos cadastrados", internalID);
                else
                {
                    internalCodeIDs.Add(new HibridToManual()
                    {
                        Command = "D",
                        Schedule = internalID,
                        Activity = code.IntegrationID,
                    });

                    internalCodeIDs.Add(new HibridToManual()
                    {
                        Command = "I",
                        Schedule = internalID,
                        Activity = code.Manual,
                    });

                    Console.WriteLine("INFO: Codigo {0} alterado com sucesso", internalID);
                }
            }

            return internalCodeIDs;
        }

        public static string GetInternalCode(string strSource)
        {
            foreach (var term in ComumTerms)
            {
                if (strSource.Contains(term))
                {
                    var end = strSource.IndexOf(term, 0);

                    return strSource.Substring(0, end);
                }
            }

            return "";
        }
    }
}
