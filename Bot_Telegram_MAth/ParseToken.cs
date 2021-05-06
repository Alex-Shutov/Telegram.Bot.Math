using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Bot_Telegram_MAth
{
    public  class ParseToken
    { 
        public readonly  string Token;
        private readonly  string path;

        private ParseToken()
        {
            path = "../../../../token.txt";
            Token = GetPath();
        }

        public static string ParseFromTxt()
        {
            var tok = new ParseToken();
            return tok.Token;
        }
        private string GetPath()
        {
            //if (File.Exists(path)) ;
                using var sr = new StreamReader(path,Encoding.UTF8);
            return sr.ReadToEnd();
        }
    }
}
