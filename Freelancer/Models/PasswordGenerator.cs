using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Freelancer.Models
{
    public class PasswordGenerator
    {
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();

            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }

            return builder.ToString();
        }

        public string RandomPassWord()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(8, true));
            /// builder.Append(RandomNumber(1000, 9999));
            
            return builder.ToString();
        }
    }
}