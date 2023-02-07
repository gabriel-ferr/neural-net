//
//  Rede Neural básica desenvolvida em C# .Net Core
//  Por Gabriel V. Ferreira
//
using System.Text;
namespace Neural
{
    /// <summary>
    /// Inicializa o programa.
    /// </summary>
    public static class Program
    {
        //
        //  Ponto de entrada do programa.
        static void Main ()
        {
            Logger.Write(Logger.MessageType.Info, "Bem-vindo! Se precisar de ajuda consulte `help`.");
            while (true)
            {
                try
                {
                    //  Habilita os comandos de CMD.
                    string? command = Console.ReadLine();
                    if (command == null) continue;

                    //  Envia o comando para tratamento.
                    Commands(command);
                }
                catch (GlobalException error)
                {
                    //  Encerra a aplicação quando ocorre alguns erros específicos.
                    if (error.Code == -1) break;
                }
            }

            //  Salva o log antes de sair.
            Logger.SaveLog().Wait();
        }

        /// <summary>
        /// Faz o tratamento de comandos e chama outras funções para realizar as tarefas necessárias.
        /// </summary>
        /// <param name="command">Comando a ser analizado.</param>
        static void Commands (string command)
        {
            try
            {
                //  Separa a mensagem em partes
                string[] line = command.Split(' ');

                //  O comando é formado na maneira: [command] [args][i]
                //  Então, vou analizar o comando recebido e chamar, se o número de argumentos é valido
                //  e deixar o resto com a função chamada.
                switch (line[0])
                {
                    //  Debug
                    case "debug":
                        Logger.Debug = !Logger.Debug;
                        break;
                    //  Encerra o programa.
                    case "exit":
                        Logger.Write(Logger.MessageType.Info, "Encerrando o programa . . .");
                        throw new GlobalException(-1);

                    //  Cria uma nova rede neural e estabelece uma relação de comando dentro dela.
                    case "new":
                        StringBuilder name = new();
                        for (int i = 1; i < line.Length - 1; i++)
                        {
                            name.Append(line[i]);
                            name.Append(' ');
                        }
                        name.Append(line[^1]);
                        //  Cria a rede neural e abre ela.
                        NeuralNetwork network = new (name.ToString());
                        network.Open();
                        break;

                    //  Carrega uma rede neural a partir de um arquivo com formado .ntk (exportado pelo programa).
                    case "load":

                        break;

                    //  Lista os comandos possíveis e as respectivas argumentações de cada comando.
                    case "help":
                        StringBuilder help = new();
                        help.Append("Está é uma lista de comandos para a lobby dos programa:\n");
                        help.Append("\tdebug - ativa ou desativa o debug.\n");
                        help.Append("\texit - encerra o programa.\n");
                        help.Append("\thelp - exibe uma lista de comandos que podem ser utilizados no ambiente carregado.\n");
                        help.Append("\tload - carrega uma rede neural salva pelo sistema com o formato `*.ntk`.\n");
                        help.Append("\t\tDeve ser usado como: load [caminho do arquivo]\n");
                        help.Append("\tnew - cria uma nova rede neural vazia (sem configurações).\n");
                        help.Append("\t\tDeve ser usado como: new [nome da rede]");
                        Logger.Write(Logger.MessageType.Info, help.ToString());
                        break;

                    default:
                        Logger.Write(Logger.MessageType.Info, "O comando utilizado é inválido.");
                        break;
                }
            } catch (GlobalException error) { throw error; } 
        }
    }
}