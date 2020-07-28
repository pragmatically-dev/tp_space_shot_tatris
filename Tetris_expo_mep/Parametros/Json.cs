using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace Tetris_expo_mep
{
   public class Json
    {
        public static void Guardar(string path,Configuracion c) {
            var datos = JsonConvert.SerializeObject(c);
            File.WriteAllText(path,datos);
        }

        public static Configuracion Deserializar(string path) {

            var Info = File.ReadAllText(path);
            Configuracion datos = JsonConvert.DeserializeObject<Configuracion>(Info);

            return datos;
        }
    }
}
