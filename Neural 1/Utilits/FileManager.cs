//
//  Script responsável pelo gerenciamento de arquivos externos ao programa.
namespace Neural
{
    /// <summary>
    /// Gerência os eventos externos ao programa.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Faz a leitura do conteúdo de um arquivo.
        /// </summary>
        /// <param name="path">Diretório do arquivo.</param>
        /// <returns>Retorna o conteúdo do arquivo sem tratamento.</returns>
        public static Task<string> Read (string path)
        {
            try
            {
                //  Faz a leitura do arquivo.
                StreamReader reader = new(path);
                string content = reader.ReadToEnd();
                reader.Close();

                return Task.FromResult(content);
            }
            catch (IOException error)
            {
                Logger.Write(Logger.MessageType.Error, error.Message);
                throw new GlobalException(1);
            }
            catch (Exception error)
            {
                Logger.Write(Logger.MessageType.Error, error.Message);
                throw new GlobalException(2);
            }
        }

        // <summary>
        /// Escreve o conteúdo de um arquivo.
        /// </summary>
        /// <param name="directory">Diretório do arquivo.</param>
        /// <param name="filename">Nome do arquivo.</param>
        /// <param name="content">Conteúdo do arquivo.</param>
        /// <returns>Rype: Task.</returns>
        public static Task Write(string directory, string filename, string content)
        {
            try
            {
                //  Exibe um erro para diretórios inexistentes.
                if (!Directory.Exists(directory)) throw new GlobalException($"O diretório `{directory}` não existe, e o programa não pode criar diretórios.", 3);

                //  Se o arquivo não existir no diretório, cria o arquivo.
                //  Caso ele exista, informa que não é possível reescrever o arquivo.
                string path = Path.Combine(directory, filename);
                if (File.Exists(path)) throw new GlobalException($"O arquivo `{filename}` já existe em `{directory}` e o programa não pode reescrever arquivos.", 4);
                else File.Create(path).Close();

                //  Escreve no arquivo.
                StreamWriter writer = new (path);
                writer.Write(content);
                writer.Close();

                return Task.CompletedTask;
            }
            catch (IOException error)
            {
                Logger.Write(Logger.MessageType.Error, error.Message);
                throw new GlobalException(1);
            }
            catch (GlobalException error)
            {
                Logger.Write(Logger.MessageType.Error, error.Message);
                throw error;
            }
            catch (Exception error)
            {
                Logger.Write(Logger.MessageType.Error, error.Message);
                throw new GlobalException(2);
            }
        }
    }
}