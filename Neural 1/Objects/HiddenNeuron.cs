//
//  Neurônio de camada oculta.
namespace Neural
{
    public class HiddenNeuron : Neuron
    {
        /// <summary>
        /// Instância um novo neurônio de camada oculta.
        /// </summary>
        /// <param name="id">ID do neurônio.</param>
        /// <param name="bias">Valor inicial da bias do neurônio.</param>
        /// <param name="activeFunction">Função de ativação que o neurônio deve utilizar.</param>
        public HiddenNeuron(long id, double bias, ActiveFunction activeFunction) : base(id, bias)
        {
            this.activeFunction = activeFunction;
        }

        //  Função de ativação do neurônio.
        private readonly ActiveFunction activeFunction;

        /// <summary>
        /// Faz a ativação do neurônio e gera um output.
        /// </summary>
        /// <returns>Retorna quando a task estiver completa</returns>
        public void Active() {
            Output = activeFunction.Active(input);
        }
    }
}