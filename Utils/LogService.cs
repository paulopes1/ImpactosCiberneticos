using System;
using System.Collections.Generic;

namespace ImpactoCiberneticoFalhasEnergia.Utils
{
    public static class LogService
    {
        private static List<string> logs = new List<string>();

        public static void RegistrarEvento(string mensagem)
        {
            string log = $"[{DateTime.Now}] {mensagem}";
            logs.Add(log);
            Console.WriteLine("(LOG) " + log);
        }

        public static void ExibirLogs()
        {
            Console.WriteLine("--- Logs do Sistema ---");
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}