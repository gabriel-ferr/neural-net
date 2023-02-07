//
//  Representa a estrutura de um neurônio individual.
//  Trata-se de uma classe abstrata, pois serão criados três tipos de neurônios.
namespace Neural
{
    /// <summary>
    /// Classe abstrata que representa um neurônio.
    /// </summary>
    public abstract class Neuron
    {
        //  Id do neurônio.
        private long id;
        //  Bias relacionada ao neurônio.
        private double bias;
        //  Saída do neurônio.
        private double output;
        //  Função de ativação do neurônio.
        private ActiveFunction activeFunction;

        /// <summary>
        /// ID do neurônio.
        /// </summary>
        public long Id { get => id; private set => id = value; }
        /// <summary>
        /// Peso da bias.
        /// </summary>
        public double Bias { get => bias; protected set => bias = value; }
        /// <summary>
        /// Output do neurônio.
        /// </summary>
        public double Output { get=> output; protected set => output = value; }

        /// <summary>
        /// Ativa um neurônio gerando um output.
        /// </summary>
        protected Task Active(double input)
        {
            output = activeFunction.Active(input);
            return Task.CompletTask;
        }
    }
}