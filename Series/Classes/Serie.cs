using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Series.Classes
{
    class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this. Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;


        }

        public override string ToString()
        {
            return 
                "Gênero: " + Genero + Environment.NewLine +
                "Título: " + Titulo + Environment.NewLine +                 
                "Descrição: " + Descricao + Environment.NewLine +
                "Ano de Lançamento: " + Ano + Environment.NewLine +
                "Excluido: " + this.Excluido;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }


        public void Excluir()
        {
            this.Excluido = true;
        }


    }
}
