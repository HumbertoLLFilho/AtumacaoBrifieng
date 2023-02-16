using Microsoft.Extensions.DependencyInjection;
using Automacao.Application.Interfaces;
using Automacao.Configurations;
using Automacao.Extensions;

var services = new ServiceCollection();

services.ConfigureServices();

var provider = services.BuildServiceProvider();

var environmentApplication = provider.GetService<IEnvironmentApplication>();
var assignmentApplication = provider.GetService<IAssignmentApplication>();

var environments = environmentApplication.Get();

bool loop = true;
while (loop)
{
    ConsoleExtension.PrintMenu();
    var typedEnvoirment = Console.ReadLine();

    var envoirment = environments.FirstOrDefault(x => x.InternalID == typedEnvoirment);

    if (envoirment is not null)
    {
        ConsoleExtension.PrintOptionsMenu();
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
                    assignmentApplication.HibridToManual(internalIDs, envoirment);

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