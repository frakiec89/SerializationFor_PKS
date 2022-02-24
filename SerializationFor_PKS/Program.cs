using System;


namespace SerializationFor_PKS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string paht = @"C:\ЗАДАНИЕ\Для ПКС-18\content.txt";
            try
            {
                ReadinFile readinFile = new ReadinFile();
                string content = readinFile.ReadinFileName(paht);

                FileParsing fileParsing = new FileParsing();
                var users = fileParsing.GetUsers(content);

                foreach (var u in users)
                {
                    Console.WriteLine(u);
                }

                SerializerJSON.UserSerializerJSON("user.json" ,  users );

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}



