using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Helpers
{
    public class SecurityHelper
    {
        public const string MembershipProviderValidationKey = "34C6EDB4BB2C2E24CE40676F6C78CDE70F24B9B69245760DF6614DD65AF376A2930F598C31A94C1CF96C3645B4887D7C11B3B25FA8F87D76FFE3F9580BD8A68E";
        public static string EncodePasswordmosso(string password)
        {
            string encodedPassword = password;
            System.Security.Cryptography.HMACSHA1 hash = new System.Security.Cryptography.HMACSHA1();
            string m_ValidationKey = MembershipProviderValidationKey;
            if ((string.IsNullOrEmpty(m_ValidationKey) || m_ValidationKey.Contains("AutoGenerate")))
                m_ValidationKey = "FE876E90EF985641A24F77B05190FADD2EE660336C233E4707D8F08457318D6333FFF117A764D57A8" + "29E9549DCEA9883FBCD4979841CD53BC810C7538507A191";
            hash.Key = HexToByte(m_ValidationKey);
            encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
            return encodedPassword;
        }
        public static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[(int)((hexString.Length / (double)2) - 1 + 1)];
            int i = 0;
            while ((i < returnBytes.Length))
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring((i * 2), 2), 16);
                i = (i + 1);
            }
            return returnBytes;
        }
    }
}
