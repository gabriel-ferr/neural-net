//
//  Função de ativação de um neurônio.
//  Por Gabriel Ferreira
namespace Neural
{
    /// <summary>
    /// Contrato da função de ativação dos neurônios.
    /// </summary>
    public interface ActiveFunction
    {
        /// <summary>
        /// Ativa a função conforme o contrato estabelecido.
        /// </summary>
        /// <param name="input">Entrada da função de ativação.</param>
        /// <returns>Saída da função.</returns>
        public double Active(double input);
    }
}