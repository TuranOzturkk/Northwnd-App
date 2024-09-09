using System;

namespace Infrastructure.Utilities
{
    public static class RandomValueGenerator
    {
        public static string GenerateFileName(string extension)
        {
            return Guid.NewGuid().ToString() + DateTime.Now.ToShortDateString() + extension;
        }

        public static string GenerateApprovingCode()
        {
            Random rnd = new Random();
            string str = "abcdefghijklmnoprstuvyz";
            str += str.ToUpper();

            string code = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                code += str[rnd.Next(str.Length)];
            }

            return code;
        }
    }
}
