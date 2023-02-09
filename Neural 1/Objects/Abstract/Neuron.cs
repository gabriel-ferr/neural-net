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
        /// <summary>
        /// Instância um novo um neurônio.
        /// </summary>
        /// <param name="id">ID do neurônio para consulta.</param>
        /// <param name="bias">BIAS do neurônio.</param>
        public Neuron (long id, double bias)
        {
            this.id = id;
            this.bias = bias;

            output = 0;
        }

        //  Id do neurônio.
        private long id;
        //  Bias relacionada ao neurônio.
        private double bias;
        //  Saída do neurônio.
        private double output;

        //  Valores armazenados na entrada do neurônio.
        protected double input;

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
    }
}