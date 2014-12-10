using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncDatabase
{
    public static class Common
    {
        public static TabPage DesabilitarComExcessoes(this TabPage tablePage)
        {
            foreach (Control ctrl in tablePage.Controls)
            {
                ctrl.Enabled = false;

            }

            return tablePage;
        }

        public static TabPage Habilitar(this TabPage tablePage)
        {
            foreach (Control ctrl in tablePage.Controls)
            {

                ctrl.Enabled = true;

            }

            return tablePage;
        }

        public static String EncryptSHA1(this String value)
        {
            /*HashAlgorithm objHashAlgorithm = new SHA1Managed();
            byte[] cryptoByte = objHashAlgorithm.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));

            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.Length);*/

            return Rijndael.Encrypt(value, "SyncD@t@b@se", "s@1tValue", "SHA1", 1, "@1B2c3D4e5F6g7H8", 128);
        }

        /// <summary>
        /// Criptografa a string com algoritmo SHA1
        /// </summary>
        /// <param name="value">Valor a ser decifrado</param>
        /// <returns>Valor decifrado</returns>
        public static String DecryptSHA1(this String value)
        {
            /*HashAlgorithm objHashAlgorithm = new SHA1Managed();
            byte[] cryptoByte = objHashAlgorithm.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));

            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.Length);*/

            return Rijndael.Decrypt(value, "SyncD@t@b@se", "s@1tValue", "SHA1", 1, "@1B2c3D4e5F6g7H8", 128);
        }
    }
}
