using System;
using System.Collections.Generic;
using System.Linq;

namespace SerializationFor_PKS
{
    public  class FileParsing
    {
        public List<User> GetUsers (string contentFull )
        {
            List<User> users = new List<User>();
            List<string> userContent = null;

            try
            {
                userContent= GetOneUserContent( contentFull );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message);
            }

            foreach (var us in userContent)
            {
                if (us!=null) users.Add(GetUser(us));
            }

            return users;
        }

        private User GetUser(string us)
        {
            List<string> user = us.Split(',').ToList();
            user = user.Where(x => string.IsNullOrWhiteSpace(x) ==false).ToList();

            if (user.Count() == 4)
            {
                string name = GetName(user[0]);
                string login = GetLogin(user[1]);
                string password = GetPasswor(user[2]);
                string seal = GetSeal(user[3]);

                return new User { Login = login, Name = name, Password = password, Seal = GetSealBinari(seal) };
            }
            else
            {
                throw new Exception("Error parsing");
            }
        }

        private byte[] GetSealBinari(string seal)
        {

             char []  chars = seal.ToArray();
           
            
            byte []  vs = new byte[chars.Length];

            for (int i = 0; i < vs.Length; i++)
            {
                if (chars[i] == '1')
                    vs[i] = 1;
                else
                    vs[i] = 0;
            }
            return vs;
        }

        private string GetSeal(string seal)
        {
            if (string.IsNullOrEmpty(seal))
                return string.Empty;

            string maska = " Соль - ";
            return seal.Substring(maska.Length - 1).TrimStart().TrimEnd();
        }

        private string GetPasswor(string pas)
        {
            if (string.IsNullOrEmpty(pas))
                return string.Empty;

            string maska = " password -  ";
            return pas.Substring(maska.Length - 1).TrimStart().TrimEnd();
        }

        private string GetLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                return string.Empty;

            string maska = " login - ";
            return login.Substring(maska.Length - 1).TrimStart().TrimEnd();
        }

        private string GetName(string name)
        {
          if (string .IsNullOrEmpty(name))
                return string.Empty;

            string maska = "Имя -  ";
            return name.Substring(maska.Length - 1).TrimStart().TrimEnd();
        }

        private List<string> GetOneUserContent(string contentFull)
        {
        
            if (contentFull == null)
            {
                throw new ArgumentException("пустая строка");
            }

            List<string> users = new List<string>();
            users = contentFull.Split('\n').ToList();
            users = users.Where(x=> (string .IsNullOrWhiteSpace(x) ) == false  ).ToList();    

            return users;
        }
    }
}
