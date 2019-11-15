using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DreamLearning.Models
{
    public class School { 
        public string Tipo { get; set; }
        public string Inep { get; set; }
        public string Nome{ get; set; }
        public string AbreviacaoNome{ get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }

        /*
         public string UrlWebsite { get; set; }
        public string Blog { get; set; }
          public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string RegiaoConselhoTutelar { get; set; }
        public string DescRegiaoConselhoTutelar { get; set; }
        public string RegiaoOP { get; set; }
        public string DescRegiaoOP { get; set; }
        public string SituacaoFuncionamento { get; set; }
        public string ConvenioMunicipal { get; set; }
        public string ConvenioEstadual { get; set; }
        public string ConvenioFedera { get; set; }
        public string  ConvenioFasc { get; set; }
        public string EscolaEspecial { get; set; }
        public string CatPartPrivada { get; set; }
        public string CatPartComunitaria{ get; set; }
        public string CatPartFilantropica{ get; set; }
        public string CatPartConfessional { get; set; }
        public string MantEmpresaPrivada { get; set; }
        public string MantEmpresaSindicato{ get; set; }
        public string MantSistemaS { get; set; }
        public string MantOng { get; set; }
        public string MantApae { get; set; }
        public DateTime DataExtracao { get; set; }
        public string DepAdministrativa{ get; set; }

         */
    }

    public class GeolocationPoint
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Inep { get; set; }

    }

    public class Address 
    {
        public string Inep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

    }
}