﻿using System;

namespace CyberPet.Api.ViewModel.Base
{
    public class BaseViewModel
    {
        /// <summary>
        /// Código identificador para atualiação do registro
        /// </summary>
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
