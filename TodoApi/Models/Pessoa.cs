using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
    }
}