﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    /// <summary>
    /// Dados do usuário
    /// </summary>
    public class TokenUsuarioResponse
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Foto do usuário
        /// </summary>
        public string? Foto { get; set; }

        /// <summary>
        /// Token do usuário
        /// </summary>
        public TokenResponse Tokens { get; set; }
    }
}
