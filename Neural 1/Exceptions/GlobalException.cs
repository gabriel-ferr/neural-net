//
//  Exceção geral do programa.
namespace Neural
{
    /// <summary>
    /// Gera uma exceção global do sistema.
    /// </summary>
    public class GlobalException : Exception
    {
        /// <summary>
        /// Lança uma nova exceção do tipo Global.
        /// </summary>
        /// <param name="code">Código de erro.</param>
        public GlobalException (int code) : base ()
        {
            this.code = code;
        }

        /// <summary>
        /// Lança uma nova exceção do tipo Global.
        /// </summary>
        /// <param name="code">Código do erro.</param>
        /// <param name="message">Mensagem de erro.</param>
        public GlobalException(string message, int code) : base(message)
        {
            this.code = code;
        }

        //  Código do erro.
        private int code;

        /// <summary>
        /// Código de erro da exceção (definido no lançamento.
        /// </summary>
        public int Code { get => code; protected set => code = value; }
    }
}