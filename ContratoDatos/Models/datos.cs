using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ContratoDatos.Models
{
    [DataContract]
    public class datos
    {
        [Key]
        [DataMember(Name = "stop_id")]

        public int ParadaId { get; set; }
        [DataMember(Name = "stop_name")]

        public string ParadaNombre { get; set; }
        [DataMember(Name = "stop_desc")]

        public string Descrip { get; set; }

        [DataMember(Name = "stop_lon")]
        public string Parada_Lon { get; set; }

        [DataMember(Name = "stop_lat")]
        public string Parada_Lat { get; set; }

        [DataMember(Name = "stop_code")]
        public string Parada_Cod { get; set; }

        [DataMember(Name = "wheelchair_boarding")]
        public int Boarding { get; set; }

    }
}