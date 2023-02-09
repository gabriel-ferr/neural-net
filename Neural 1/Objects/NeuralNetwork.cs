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
                            Console.Title = "Programa de testes para rede neural";
                            Logger.Debug = !Logger.Debug;
                            break;

                        //  Encerra a rede neural.
                        case "exit":
                            Logger.Write(Logger.MessageType.Info, "Encerrando a rede neural . . .");
                            running = false;
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