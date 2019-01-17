using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Disco
    {
        public Disco(int discoId, string titulo, int anyo, string grupo)
        {
            DiscoId = discoId;
            Titulo = titulo;
            Anyo = anyo;
            Grupo = grupo;
        }

        public int DiscoId { get; set; }
        public string Titulo { get; set; }
        public int Anyo { get; set; }
        public string Grupo { get; set; }
    }
}