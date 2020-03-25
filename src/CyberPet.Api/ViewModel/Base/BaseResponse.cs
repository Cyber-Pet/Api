using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.ViewModel.Base
{
    public class BaseResponse
    {
        /// <summary>
        /// Código identificador para atualiação do registro
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da ultima atualização do registro
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
