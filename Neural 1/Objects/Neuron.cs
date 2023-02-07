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

        /// <summary>
        /// ID do neurônio.
        /// </summary>
        public long Id { get => id; private set => id = value; }
    }

}