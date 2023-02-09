//
//  Função de ativação sigmoide.
namespace Neural.Functions
{
    /// <summary>
    /// Função de ativação sigmoide.
    /// </summary>
    public sealed class Sigmoid : ActiveFunction
    {
        /// <summary>
        /// Ativa a função de ativação sigmoide.
        /// </summary>
        /// <param name="input">Valor de entrada na função.</param>
        /// <returns>Retorna a saída da função de ativação.</returns>
        double ActiveFunction.Active(double input)
        {
            return 1 / (1 + (Math.Pow(Math.E, -input)));
        }
    }
}