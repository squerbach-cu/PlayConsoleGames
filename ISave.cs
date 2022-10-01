using System;

namespace PlayConsoleGames
{
    internal interface ISave
    {
        //not sure why i did this with a interface, but maybe in the future there is a 2nd way of saving
        /// <summary>
        /// Creates a Json and puts the contenet of a GameState object and the name of the game into it
        /// </summary>
        /// <param name="objectToSerialize"></param>
        void SaveToMedium(Object objectToSerialize);
        /// <summary>
        /// loads from 
        /// </summary>
        /// <returns></returns>
        Object LoadFromMedium();
        /// <summary>
        /// gets the name of the object, that has been serialised and "maps it to the corresponding game index.
        /// </summary>
        /// <returns></returns>
        int GetGameIndex();
    }
}
