//
//  Estrutura responsável por montar e gerenciar a rede neural.
//  Por Gabriel Ferreira.
using System.Text;

namespace Neural
{
    /// <summary>
    /// Estrutura responsável por montar e gerenciar uma rede neural.
    /// </summary>
    public sealed class NeuralNetwork
    {
        //  Nome da rede neural - vai ser utilizado apenas na hora de salvar.
        private string name;

        /// <summary>
        /// Instância uma nova rede neural.
        /// </summary>
        /// <param name="name">Nome da rede neural.</param>
        public NeuralNetwork(string name)
        {
            if (name.Contains('\\') || name.Contains('/') || name.Contains('?') || name.Contains('|') || name.Contains('&') || name.Contains('%') || name.Contains('$') || string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Logger.Write(Logger.MessageType.Error, "O nome da rede neural é inválido. Evite usar caracteres especiais.");
                throw new GlobalException(5);
            }
            this.name = $"{name}.ntk";
        }

        /// <summary>
        /// Abre a instância da rede neural.
        /// </summary>
        public void Open ()
        {
            Console.Title = $"Rede neural: {name}";
            try
            {
                bool running = true;
                while (running)
                {
                    //  Habilita os comandos de CMD dentro da instância da rede neural.
                    string? command = Console.ReadLine();
                    if (command == null) continue;

                    //  Trata as entradas.
                    string[] line = command.Split(' ');
                    switch (line[0])
                    {
                        //  Debug
                        case "debug":
                            Logger.Debug = !Logger.Debug;
                            break;

                        //  Encerra a rede neural.
                        case "exit":
                            Logger.Write(Logger.MessageType.Info, "Encerrando a rede neural . . .");
                            running = false;
                            break;

                        //  Cria alguma coisa.
                        case "new":

                            break;

                        //  Remove algo.
                        case "remove":

                            break;

                        //  Carrega alguma coisa.
                        case "load":

                            break;

                        //  Treina a rede.
                        case "apprend":

                            break;

                        //  Testa a rede.
                        case "test":

                            break;

                        //  Salva a rede.
                        case "save":

                            break;

                        //  Exporta a rede/
                        case "export":

                            break;

                        //  Ajuda
                        case "help":
                            StringBuilder help = new();
                            help.Append("Está é uma lista de comandos para a instância de rede neural do programa:\n");
                            help.Append("\tapprend - aprende a partir de uma base de dados.\n");
                            help.Append("\t\t1) apprend [nome dos dados (a-Z)]\n");
                            help.Append("\t\t2) apprend seno\n");
                            help.Append("\tdebug - ativa ou desativa o debug.\n");
                            help.Append("\tremove - deleta algum objeto.\n");
                            help.Append("\t\t1) remove layer [id]\n");
                            help.Append("\t\t2) remove neuron [id]\n");
                            help.Append("\t\t3) remove connection [id]\n");
                            help.Append("\t\t4) remove neuron-connection [id]\n");
                            help.Append("\t\t5) remove data [id]\n");
                            help.Append("\texit - encerra a instância. Cuidado, pois ele não salva!\n");
                            help.Append("\texport - exporta um conjunto de dados.\n");
                            help.Append("\t\t1) export weigth [diretório] [nome do arquivo]\n");
                            help.Append("\t\t2) export output [diretório] [nome do arquivo]\n");
                            help.Append("\thelp - exibe uma lista de comandos que podem ser utilizados no ambiente carregado.\n");
                            help.Append("\tload - carrega algo pré-determinado.\n");
                            help.Append("\t\t1) load data [nome dos dados (a-Z)] [caminho do arquivo em formato .csv]\n");
                            help.Append("\tnew - cria alguma coisa nova na rede.\n");
                            help.Append("\t\t1) new layer [tipo: hidden, perception, output]\n");
                            help.Append("\t\t2) new neuron [função de ativação] [layer] [quantidade (default: 1)]\n");
                            help.Append("\t\t3) new connection [layer que envia] [layer que recebe]\n");
                            help.Append("\t\t4) new neuron-connection [neuronio que envia] [neuronio que recebe]\n");
                            help.Append("\t\t5) new data [nome do conjunto de dados]\n");
                            help.Append("\tsave - salva a rede neural.\n");
                            help.Append("\t\tDeve ser usado como: save [caminho do arquivo] [nome do arquivo (por padrão é o nome da rede)]\n");
                            help.Append("\ttest - realiza um teste da rede neural.\n");
                            help.Append("\t\tDeve ser usado como: test [valor de entrada / nome dos dados de entrada]");
                            Logger.Write(Logger.MessageType.Info, help.ToString());
                            break;

                        default:
                            Logger.Write(Logger.MessageType.Info, "O comando utilizado é inválido.");
                            break;
                    }
                }
            } catch (GlobalException error) { throw error; }
        }
    }
}