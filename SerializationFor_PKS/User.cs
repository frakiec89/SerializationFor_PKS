using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationFor_PKS
{
    public class User
    {
        public string Name { get; set; }    
        public string Login { get; set; }
        public string Password { get; set; }
        public byte []  Seal { get; set; }

        public override string ToString()
        {
            string s = GetSealString();

            return $"{Name},  {Login}, {Password} {s}";
        }

        private string GetSealString()
        {
          string  s = string.Empty;

            foreach (var item in Seal)
            {
                s += item;
            }
            return s;
        }
    }
}
