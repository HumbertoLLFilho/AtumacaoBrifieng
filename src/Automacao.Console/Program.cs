using Automacao.Core.Extensions;
using Automacao.Domain.Services;
using Automacao.Infra.Services;

var big = new Automacao.Core.Environment()
{
    Name = "Big",
    InternalID = "pmbg01",
};

big.AddCodes();

var envoirments = new List<Automacao.Core.Environment>()
{
    big
};

bool loop = true;
while (loop)
{
    Console.WriteLine("#--------------------------------------#");
    Console.WriteLine("| Digite qual ambiente deseja alterar  |");
    Console.WriteLine("|          ou 0 para SAIR              |");
    Console.WriteLine("#--------------------------------------#");
    Console.Write("Codigo do ambiente: ");

    var typedEnvoirment = Console.ReadLine();

    var envoirment = envoirments.FirstOrDefault(x => x.InternalID == typedEnvoirment);

    if (envoirment is not null)
    {
        Console.WriteLine("\n#--------------------------------------#");
        Console.WriteLine("|        O que deseja realizar?        |");
        Console.WriteLine("#--------------------------------------#");
        Console.WriteLine("|    1- Troca de hibrido para manual   |");
        Console.WriteLine("|                                      |");
        Console.WriteLine("|            0 - Voltar                |");
        Console.WriteLine("#--------------------------------------#");
        Console.Write("Opção: ");

        var resp = Console.ReadLine();

        if (resp == "1")
        {
            Console.WriteLine("\nDigite as tarefas a serem trocadas:");

            var isValidCode = true;
            var internalIDs = new List<string>();
            int i = 1;
            while (isValidCode)
            {
                Console.Write($"Tarefa N°{i}:");
                var resp1 = Console.ReadLine();

                if (resp1 == "")
                {
                    var results = AssignmentService.HibridToManual(internalIDs, envoirment.Codes);

                    CsvInfra.SaveData(results, @"C:\Users\Humberto\Documents\Automacao\Big\AAG_HIBRID-TO-MANUAL-HUMBERTO_V2.csv");

                    isValidCode = false;
                }
                else
                {
                    internalIDs.Add(resp1);

                    i++;
                }
            }
        }

    }
    else if(typedEnvoirment == "0")
        loop = false;
}