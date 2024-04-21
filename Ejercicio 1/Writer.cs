using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    public class Writer : Ireposity
    {
        public async Task<object> Aux(string paths, string texto)
        {
            using (StreamWriter sw = new StreamWriter(paths,false))
            {
                string texto_en_mayuscula = texto.ToUpper();
                await sw.WriteAsync(texto_en_mayuscula);
                return sw;
            }
        }
    }
}
