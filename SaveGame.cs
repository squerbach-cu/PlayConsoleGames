using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using PlayConsoleGames.Connect4;
using PlayConsoleGames.PlayTowersOfHanoi;
using PlayConsoleGames.TicTacToe;
using Newtonsoft.Json.Linq;

namespace PlayConsoleGames
{
    public class SaveGame : ISave
    {
        public void SaveToMedium(object objectToSerialize)
        {
            var type = objectToSerialize.GetType();            
            
            string jsonString = JsonConvert.SerializeObject(objectToSerialize);
            string base64encoded = Base64Encode(jsonString);                        

            //concatenate the 2 strings:
            string stringToSave = type.Name + ";" + base64encoded;

            var dir = Environment.CurrentDirectory;            
            File.WriteAllText(dir + "\\Savegame.json", stringToSave);             
        }

        public object LoadFromMedium()
        {
            //Get the file to load from
            var dir = Environment.CurrentDirectory; 
            string fileName = dir + "\\Savegame.json";
            string fileContent = File.ReadAllText(fileName); 
            
            //get the base64 json part and decode it 
            string base64Substring = fileContent.Substring(fileContent.LastIndexOf(';') + 1);
            string decodedSaveFile = Base64Decode(base64Substring);

            var saveGame = JsonConvert.DeserializeObject<JObject>(decodedSaveFile);  

            File.Delete(fileName);
            return saveGame;            
        }
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
               

        public int GetGameIndex()
        {
            var dir = Environment.CurrentDirectory;
            string fileName = dir + "\\Savegame.json";
            string fileContent = File.ReadAllText(fileName);
            string gameName = String.Concat(fileContent.TakeWhile(c => c != ';'));

            switch (gameName)
            {
                case "GameStatusTowersOfHanoi":
                    return 1;

                case "GameStatusC4":
                    return 2;

                case "GameStatusTicTacToe":
                    return 3;                
            }
            return 0;
        }
    }
}
