using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiUsuarioAdministrador.Models
{
    public class ProductoUsuarioDto_
    {
        [Newtonsoft.Json.JsonProperty("idUsuarioProducto", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IdUsuarioProducto { get; set; }

        [Newtonsoft.Json.JsonProperty("idUsuario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IdUsuario { get; set; }

        [Newtonsoft.Json.JsonProperty("idProducto", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IdProducto { get; set; }


    }
}

