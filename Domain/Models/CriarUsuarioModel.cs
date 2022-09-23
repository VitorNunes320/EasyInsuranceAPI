﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    /// <summary>
    /// Dados de criação do usuário
    /// </summary>
    public class CriarUsuarioModel
    {
        public CriarUsuarioModel(string nome, string email, string senha, List<Guid> perfis)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Perfis = perfis;
        }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Email utilizado para realizar o login
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Senha utilizada para realizar o login
        /// </summary>
        [Required]
        public string Senha { get; set; }

        /// <summary>
        /// Perfis do usuário
        [Required]
        public List<Guid> Perfis { get; set; }
    }
}
