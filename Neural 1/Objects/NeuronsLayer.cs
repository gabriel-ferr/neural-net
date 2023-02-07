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

        //  Id da camada para gerenciamento.
        private long id;

        /// <summary>
        /// ID da camada de neurônios.
        /// </summary>
        public long Id { get => id; private set => id = value; }
    }
}