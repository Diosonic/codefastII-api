﻿using System.Text.Json.Serialization;

namespace Codefast.Models
{
    public class ControleEliminatoria
    {
        public int Id { get; set; }
        public string StatusValidacao { get; set; } = string.Empty;
        public bool IsDesclassificado { get; set; }
        public int Pontuacao { get; set; }

        public int EquipeId { get; set; }

        [JsonIgnore]
        public Equipe Equipe { get; set; } = null!;
    }
}