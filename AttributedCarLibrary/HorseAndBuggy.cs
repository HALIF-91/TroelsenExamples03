using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary
{
    [Serializable]
    [Obsolete("Use another vehicle!")]
    // [Obsolete("Use another vehicle!")] помечает тип или член как устаревший
    [VehicleDescription("The old gray mare, she ain't what she used to be ...")]
    public class HorseAndBuggy
    {

    }
}
