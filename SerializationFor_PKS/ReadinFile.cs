using System;
using System.IO;
using System.Text;

namespace SerializationFor_PKS
{
    internal class ReadinFile
    {

        private  Encoding _defaulEndoding = Encoding.UTF8;

        public string ReadinFileName (string paht , Encoding encoding)
        {
            try
            {
                using (StreamReader sw = new StreamReader(paht, encoding))
                {
                    return sw.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ReadinFileName(string paht)
        {
            return ReadinFileName(paht, _defaulEndoding);
        }


        public void WriteFileName(string paht ,string content)
        {
            WriteFileName(paht, content, _defaulEndoding);
        } 

        public void WriteFileName(string paht , string content , Encoding encoding)
        {
            try
            {
                File.AppendAllText(paht, content , encoding);
            }
            catch
            {
                throw new Exception("Error Save json");
            }
        }
    }
}
