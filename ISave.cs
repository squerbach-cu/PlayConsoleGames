using System;

namespace PlayConsoleGames
{
    internal interface ISave
    {
        void SaveToMedium(Object objectToSerialize);
        Object LoadFromMedium();
        int GetGameIndex();
    }
}
