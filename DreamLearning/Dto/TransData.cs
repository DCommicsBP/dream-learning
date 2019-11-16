using DreamLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DreamLearning.Dto
{
    public class TransData
    {
        public List<Address> Addresses { get; set; }
        public List<GeolocationPoint> Points {get; set;}
        public List<School> Schools { get; set; }
    }
}