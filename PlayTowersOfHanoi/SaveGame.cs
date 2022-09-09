using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PlayConsoleGames.PlayTowersOfHanoi
{
    internal class SaveGame
    {
        private static void SafeToJson(SaveGame boardToSafe)
        {
            var boardJson = JsonConvert.SerializeObject(boardToSafe);
            File.WriteAllText(@"C:\TFS\CodingPractice\" + "Safegame.json", boardJson);
            var dir = Environment.CurrentDirectory;
        }

        private static void LoadFromJson(SaveGame boardToLoadJsonInto)
        {
            string boardStringFromJson = File.ReadAllText(@"C:\TFS\CodingPractice\Safegame.json");

            boardToLoadJsonInto = JsonConvert.DeserializeObject<SaveGame>(boardStringFromJson);
        }
    }
}
