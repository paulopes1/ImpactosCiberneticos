using System;
using System.Collections.Generic;
using ImpactoCiberneticoFalhasEnergia.Models;
using ImpactoCiberneticoFalhasEnergia.Utils;

namespace ImpactoCiberneticoFalhasEnergia.Services
{
    public class Sistema
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Falha> falhas = new List<Falha>();
        private Usuario usuarioLogado = null;

        public void Iniciar()
        {
            Console.WriteLine("=== Sistema de Monitoramento de Falhas ===");
            while (true)
            {
                Console.WriteLine("\n1 - Cadastrar Usuário\n2 - Login\n0 - Sair");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1": Cadastrar(); break;
                    case "2": if (Login()) Menu(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        private void Cadastrar()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            usuarios.Add(new Usuario(nome, senha));
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        private bool Login()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            foreach (var u in usuarios)
            {
                if (u.Nome == nome && u.Senha == senha)
                {
                    usuarioLogado = u;
                    Console.WriteLine("Login bem-sucedido.");
                    return true;
                }
            }
            Console.WriteLine("Usuário ou senha inválidos.");
            return false;
        }

        private void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1 - Registrar Falha\n2 - Gerar Alerta\n3 - Ver Logs\n4 - Relatório\n5 - Simular Ameaça\n0 - Sair");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1": RegistrarFalha(); break;
                    case "2": GerarAlerta(); break;
                    case "3": LogService.ExibirLogs(); break;
                    case "4": GerarRelatorio(); break;
                    case "5": SimularAmeaca(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        private void RegistrarFalha()
        {
            try
            {
                Console.Write("Data (dd/mm/yyyy): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Local: ");
                string local = Console.ReadLine();
                Console.Write("Impacto: ");
                string impacto = Console.ReadLine();
                Console.Write("Serviço Afetado: ");
                string servico = Console.ReadLine();

                var falha = new Falha(data, local, impacto, servico);
                falhas.Add(falha);
                LogService.RegistrarEvento("Falha registrada: " + falha.ToString());
                Console.WriteLine("Falha registrada com sucesso.");
            }
            catch (Exception e)
            {
                LogService.RegistrarEvento("Erro ao registrar falha: " + e.Message);
                Console.WriteLine("Erro nos dados fornecidos. Tente novamente.");
            }
        }

        private void GerarAlerta()
        {
            if (falhas.Count == 0)
            {
                Console.WriteLine("Nenhuma falha registrada.");
                return;
            }
            var ultima = falhas[falhas.Count - 1];
            Console.WriteLine("Alerta: Nova falha registrada!");
            Console.WriteLine(ultima);
            LogService.RegistrarEvento("Alerta gerado para falha: " + ultima.ToString());
        }

        private void GerarRelatorio()
        {
            Console.WriteLine("--- Relatório de Falhas ---");
            foreach (var f in falhas)
            {
                Console.WriteLine(f);
            }
            LogService.RegistrarEvento("Relatório gerado com " + falhas.Count + " falhas.");
        }

        private void SimularAmeaca()
        {
            Console.WriteLine("Simulando ameaça após falha...");
            Console.WriteLine("Risco identificado: reinicialização não segura de serviço!");
            LogService.RegistrarEvento("Simulação de ameaça cibernética realizada.");
        }
    }
}