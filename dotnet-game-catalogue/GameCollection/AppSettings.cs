using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection
{
    public static class AppSettings
    {
        public static string Secret { get; }

        static Random _rand = new Random();

        const int SECRET_SIZE = 128;

        static AppSettings()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0;i<SECRET_SIZE;++i)
            {
                sb.Append((char)_rand.Next(32, 128));
            }
            Secret = sb.ToString();
            
        }
    }
}
