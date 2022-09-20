using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using PlayConsoleGames.Connect4;

namespace PlayConsoleGames
{
    public class SaveGame : ISave
    {
        public void SaveToMedium(object objectToSerialize)
        {
            var type = objectToSerialize.GetType();
            string typeString = JsonConvert.SerializeObject(type);
            string jsonString = JsonConvert.SerializeObject(objectToSerialize);
            string base64encoded = Base64Encode(jsonString);
            string base64encodedType = Base64Encode(typeString);            

            //concatenate the 2 strings:
            string stringToSave = base64encodedType + ";" + base64encoded;

            var dir = Environment.CurrentDirectory;            
            File.WriteAllText(dir + "\\Savegame.json", stringToSave);             
        }

        public object LoadFromMedium()
        {
            //Get the file to load from
            var dir = Environment.CurrentDirectory; 
            string fileName = dir + "\\Savegame.json";
            string fileContent = File.ReadAllText(fileName); 
            //get the "prefix" aka the type of the object
            string objectName = String.Concat(fileContent.TakeWhile(c => c != ';'));
            string decodedType = Base64Decode(objectName);
            //get the  part and decode it 
            string base64Substring = fileContent.Substring(fileContent.LastIndexOf(';') + 1);
            string decodedSaveFile = Base64Decode(base64Substring);


            var type = JsonConvert.DeserializeObject<Type>(decodedType);
            var saveGame3 = JsonConvert.DeserializeObject<object>(decodedSaveFile);



            var typedfg = Convert.ChangeType(saveGame3, type);
            var typedfg = (type)saveGame3;
            //var saveGame = JsonConvert.DeserializeObject<object>(decodedType);

            //File.Delete(fileName);
            return typedfg;
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

        private static void PrefixPlusBase64String()
        {
                        
        }
    }
}
