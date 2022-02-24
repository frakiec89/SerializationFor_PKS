using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SerializationFor_PKS
{
    internal class SerializerJSON
    {
        public  static void UserSerializerJSON (string path , List<User> users)
        {
            try
            {
                var  options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                ReadinFile readinFile = new ReadinFile();
                string jsonString = JsonSerializer.Serialize(users , options);
                readinFile.WriteFileName(path, jsonString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
