using System.Security.Cryptography;
using System.Text;

namespace BlogTJMT.Common.Security
{
    public static class EncryptString
    {
        public static string Encrypta(this string valor)
        {
            valor += "|!@_ekLMSpcwUq.PIdgiL3PE)R.pNdt]_!$!";
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(valor));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }



    }
}
