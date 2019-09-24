using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace evasystem.Helpers
{
    public class SendCodeHelper
    {
        SendCodeEncode oSendCodeEncode;
        //private string TokenLength = WebConfigurationManager.AppSettings["TokenLength"];
        private string TokenLength = "7";
        public SendCodeHelper()
        {
            oSendCodeEncode = new SendCodeEncode();
        }
        /// <summary>
        /// 取得驗證碼(預設15碼 英文+數字)
        /// </summary>
        /// <param name="length">驗證碼長度</param>
        /// <param name="type"></param>
        /// <returns>驗證碼</returns>
        public string GetSendCodeStr(int length = 15, SendCodeType type = SendCodeType.Mix)
        {
            int.TryParse(TokenLength, out length);
            string reuslt = string.Empty;

            reuslt = this.GetRandomStr(length, type);

            return reuslt;
        }
        public enum SendCodeType
        {
            Number,
            ABC,
            Mix
        }
        private string GetRandomStr(int length, SendCodeType type)
        {
            string str = "";
            int beginChar = 'a';
            int endChar = 'z';

            switch (type)
            {
                case SendCodeType.Number:
                    beginChar = 'z' + 1;
                    endChar = 'z' + 10;
                    break;
                case SendCodeType.ABC:
                    beginChar = 'a';
                    endChar = 'z';
                    break;
                case SendCodeType.Mix:
                default:
                    beginChar = 'a';
                    endChar = 'z' + 10;
                    break;
            }

            // 生成隨機類
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                //int tmp = (beginChar + random.Next(endChar - beginChar));
                int tmp = (beginChar + VulnerabilityHelper.RNG_Random.RNG_Next(endChar - beginChar - 1));
                // 大於'z'的是數字
                if (tmp > 'z')
                {
                    tmp = '0' + (tmp - 'z');
                }
                str += (char)tmp;
            }

            return str;
        }

        public class SendCodeEncode
        {
            public enum EncodeAlgorithm
            {
                SHA256,
                SHA384,
                SHA512
            }
            public string Encode(EncodeAlgorithm algorithm, string value)
            {
                string result = string.Empty;
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Wrong Input");

                try
                {
                    byte[] source = Encoding.Default.GetBytes(value);
                    switch (algorithm)
                    {
                        case EncodeAlgorithm.SHA256:
                            result = SHA256_Hash(source);
                            break;
                        case EncodeAlgorithm.SHA384:
                            result = SHA384_Hash(source);
                            break;
                        case EncodeAlgorithm.SHA512:
                        default:
                            result = SHA512_Hash(source);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
            private static string SHA256_Hash(byte[] source)
            {
                SHA256 sha256 = new SHA256CryptoServiceProvider();//建立SHA256
                byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
                return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            }
            private static string SHA384_Hash(byte[] source)
            {
                SHA384 sha384 = new SHA384CryptoServiceProvider();//建立SHA384
                byte[] crypto = sha384.ComputeHash(source);//進行SHA384加密
                return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            }
            private static string SHA512_Hash(byte[] source)
            {
                SHA512 sha512 = new SHA512CryptoServiceProvider();//建立一個SHA512
                byte[] crypto = sha512.ComputeHash(source);//進行SHA512加密
                return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            }
        }
    }
}