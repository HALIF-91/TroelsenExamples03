using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]
namespace AttributedCarLibrary
{
    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    {
        // Тип ulong не отвечает спецификации CLS, компилятор выдаст предупреждение
        public ulong notCompliant;
    }
}
