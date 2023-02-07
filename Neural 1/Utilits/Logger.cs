//
//  Script responsável pelo gerenciamento dos textos do console e
//  geração de logs de falhas ou debug.
using System.Text;
namespace Neural
{
    /// <summary>
    /// Evento responsável por gerenciar os dados de entrada e saída do sistema.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Tipo de mensagem a ser tratada.
        /// </summary>
        public enum MessageType
        {
            Error,
            Debug,
            Info,
            Output,
            Input,
        }

        //  Log de mensagens do sistema.
        private readonly static List<string> Log = new ();

        /// <summary>
        /// Determina se o modo de debug está ativado ou desativado.
        /// </summary>
        public static bool Debug = false;

        /// <summary>
        /// Imprime uma mensagem no console.
        /// </summary>
        /// <param name="type">Tipo de mensagem a ser impressa.</param>
        /// <param name="message">Mensagem a ser impressa.</param>
        /// <returns>Type: Task</returns>
        public static Task Write(MessageType type, string message)
        {
            //  Se o modo debug estiver inativado, evita mensagens de debug.
            if ((type == MessageType.Debug) && (!Debug)) return Task.CompletedTask;

            //  Muda a coloração do texto de acordo com o tipo de mensagem.
            if (type == MessageType.Error) Console.ForegroundColor = ConsoleColor.Red;
            else if (type == MessageType.Debug) Console.ForegroundColor = ConsoleColor.Gray;
            else if (type == MessageType.Info) Console.ForegroundColor = ConsoleColor.Cyan;
            else if (type == MessageType.Output) Console.ForegroundColor = ConsoleColor.Magenta;
            else if (type == MessageType.Output) Console.ForegroundColor = ConsoleColor.DarkGreen;
            else Console.ForegroundColor = ConsoleColor.DarkGray;

            //  Monta a string de saída
            string print = $"[{type.ToString().ToUpper()}] {message}";

            //  Imprime a mensagem.
            Console.WriteLine(print);
            Console.ForegroundColor = ConsoleColor.DarkGray;

            //  Salva a mensagem ao log e encerra a aplicação.
            Log.Add(print);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Salva o log de dados.
        /// </summary>
        public static async Task SaveLog ()
        {
            //  Quantidade de mensagens a serem salvas.
            int messagesToSave = Log.Count;

            //  Monta o conteúdo do log.
            StringBuilder log = new();
            for (int i = 0; i < messagesToSave; i++)
            {
                log.Append(Log[i]);
            }

            //  Salva o arquivo de log e limpa ele.
            Task save = FileManager.Write($"{Directory.GetCurrentDirectory}/log", $"{DateTime.Now.ToUniversalTime():yyyy-MM-dd hh-mm-ss fffff}.log", log.ToString());
            Log.RemoveRange(0, messagesToSave);
            await save;
        }
    }
}
