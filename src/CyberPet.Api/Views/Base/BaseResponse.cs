using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Views.Base
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
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// Data da ultima atualização do registro
        /// </summary>
        public DateTime UpdateAt { get; set; }
    }
}
