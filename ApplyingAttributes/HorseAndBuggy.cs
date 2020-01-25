using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    [Serializable, Obsolete("Use another vehicle!")]
    // [Obsolete("Use another vehicle!")] помечает тип или член как устаревший
    class HorseAndBuggy
    {

    }
}
