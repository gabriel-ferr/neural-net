//
//  Representa uma camada de neurônios que podem ser manipulados como um conjunto.
//  Perceba que é possível conectar neurônios individualmente (ou eu planejo fazer isso futuramente kkkk)
//  Porém, essa alternativa é pouco viável devido a formatação do código.
//  Por Gabriel Ferreira
namespace Neural
{
    /// <summary>
    /// Camada de neurônios da rede neural.
    /// </summary>
    public sealed class NeuronsLayer
    {
        /// <summary>
        /// Tipo de camada neural (isso limitará os neurônios que podem interagir e preencher ela).
        /// </summary>
        public enum Type
        {
            Hidden,
            Perception,
            Output
        }

        /// <summary>
        /// Instância uma nova camada e os neurônios que a compõem.
        /// </summary>
        /// <param name="id">ID da camada.</param>
        /// <param name="type">Tipo dos neurônios que pertencem a camada.</param>
        /// <param name="neurons">Número de neurônios presentes na camada.</param>
        /// <param name="useBias">Deve ser utilizado uma bias de valor aleatório?</param>
        /// <param name="function">Função de ativação que deve ser utilizada nos neurônios da camada.</param>
        public NeuronsLayer (long id, Type type, uint neurons, bool useBias, ActiveFunction function)
        {
            this.id = id;
            this.type = type;

            this.neurons = new ();

            double bias = 0;
            Random rnd = new Random((int) DateTime.Now.Ticks);

            //  Instância os neurônios.
            for (uint i = 0; i < neurons; i++)
            {
                if (useBias) bias = rnd.NextDouble();
                if (type == Type.Hidden) this.neurons.Add(new HiddenNeuron(this.neurons.Count - 1, bias, function));
            }
        }

        //  Id da camada para gerenciamento.
        private long id;
        //  Tipo de neurônios presentes na camada.
        private Type type;
        //  Neurônios que compõem a camada.
        private readonly List<Neuron> neurons;

        /// <summary>
        /// ID da camada de neurônios.
        /// </summary>
        public long Id { get => id; private set => id = value; }
        /// <summary>
        /// Tipo dos neurônios presentes na camada.
        /// </summary>
        public Type LayerType { get => type; private set => type = value; }

        /// <summary>
        /// Envia um pulso entre os neurônios para enviar as informações entre as sinapses.
        /// </summary>
        public Task Pulse ()
        {
            
            return Task.CompletedTask;
        }

        /// <summary>
        /// Ativa todos os neurônios da camada.
        /// </summary>
        public Task ActiveNeurons()
        {
            foreach (HiddenNeuron neuron in neurons) neuron.Active();
            return Task.CompletedTask;
        }
    }
}