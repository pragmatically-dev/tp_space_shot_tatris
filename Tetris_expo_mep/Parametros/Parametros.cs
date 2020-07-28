using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Tetris_expo_mep
{
   

    public partial class Configuracion
    {
        [JsonProperty("Dificultad", NullValueHandling = NullValueHandling.Ignore)]
        public Dificultad Dificultad { get; set; }

        [JsonProperty("Colores", NullValueHandling = NullValueHandling.Ignore)]
        public Colores Colores { get; set; }
    }

    public partial class Colores {

        [JsonProperty("ByN")]
        public bool ByN { get; set; }

        [JsonProperty("AyN")]
        public bool AyN { get; set; }

        [JsonProperty("RyN")]
        public bool RyN { get; set; }
    }

    public partial class Dificultad
    {
        [JsonProperty("Facil")]
        public bool Facil { get; set; }

        [JsonProperty("Normal")]
        public bool Normal { get; set; }

        [JsonProperty("Dificil")]
        public bool Dificil { get; set; }
    }
}
