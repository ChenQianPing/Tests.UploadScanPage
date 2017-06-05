using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UploadScanPage
{
    public class Md5CheckerHelper
    {
        #region GetMd5HashFromFile
        /// <summary>
        /// 获取文件的MD5值.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMd5HashFromFile(string fileName)
        {
            try
            {
                var file = new FileStream(fileName, FileMode.Open);
                var md5 = new MD5CryptoServiceProvider();
                var retVal = md5.ComputeHash(file);
                file.Close();

                var sb = new StringBuilder();
                var i = 0;
                for (; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail, error:" + ex.Message);
            }
        }
        #endregion
    }
}
