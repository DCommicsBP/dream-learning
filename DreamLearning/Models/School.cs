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
        public string Telefone { get; set; }
    }

    public class GeolocationPoint
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Inep { get; set; }

    }

    public class Address 
    {
        public string Inep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }

    }
}