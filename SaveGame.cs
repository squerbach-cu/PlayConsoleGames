using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PlayConsoleGames
{
    internal class SaveGame : ISave
    {
        public void SaveToMedium(SaveGame boardToSafe)
        {
            var boardJson = JsonConvert.SerializeObject(boardToSafe);
            File.WriteAllText(@"C:\TFS\CodingPractice\" + "Safegame.json", boardJson);
            var dir = Environment.CurrentDirectory;
        }

        public void LoadToMedium(SaveGame boardToLoadJsonInto)
        {
            string boardStringFromJson = File.ReadAllText(@"C:\TFS\CodingPractice\Safegame.json");

            boardToLoadJsonInto = JsonConvert.DeserializeObject<SaveGame>(boardStringFromJson);
        }

        public void SaveToMedium()
        {
            throw new NotImplementedException();
        }

        public void LoadToMedium()
        {
            throw new NotImplementedException();
        }
    }
}
