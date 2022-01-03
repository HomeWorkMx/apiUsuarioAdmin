using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiUsuarioAdministrador.Entities;

namespace apiUsuarioAdministrador.Models
{
    public partial class ProveedorTipoDireccionDto
    {
        [Newtonsoft.Json.JsonProperty("idTipoUsuario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IdTipoUsuario { get; set; }

        [Newtonsoft.Json.JsonProperty("idUsuario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IdUsuario { get; set; }

        [Newtonsoft.Json.JsonProperty("nombreTipo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NombreTipo { get; set; }

        [Newtonsoft.Json.JsonProperty("descripcionTipo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DescripcionTipo { get; set; }

        [Newtonsoft.Json.JsonProperty("nombreUsuario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NombreUsuario { get; set; }

        [Newtonsoft.Json.JsonProperty("descripcionUsuario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DescripcionUsuario { get; set; }
        public List<DireccionDto> DireccionesProveedor  { get; set; }

        public decimal EstrellasPromedio { get; set; }


    }


}


