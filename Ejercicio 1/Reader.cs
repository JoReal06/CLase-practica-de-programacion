using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    public class Reader : Ireposity
    {
        public async Task<object> Aux(string paths, string texto)
        {
            using (StreamReader sr= new StreamReader(paths))
            { 
                string texto_del_archivo = await sr.ReadToEndAsync();
                return texto_del_archivo;
            }
        }
    }
}
