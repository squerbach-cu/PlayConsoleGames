using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames
{
    internal interface ISave
    {
        void SaveToMedium(Object objectToSerialize);
        Object LoadFromMedium();
        int GetGameIndex();
    }
}
