using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

namespace WSPublic.BE
{
    [Serializable]
    public class InvoiceDataWS
    {
        public InvoiceWS Invoice { get; set; }
        public List<InvoiceDetailsWS> ListInvoiceDetailsWS { get; set; }       

        /// <summary>
        /// True: cấp hóa đơn trống, false: cấp hóa đơn bình thường
        /// </summary>
        public bool IsSetInvoiceNo { get; set; }

        public InvoiceDataWS()
        {
            Invoice = new InvoiceWS();
            ListInvoiceDetailsWS = new List<InvoiceDetailsWS>();
            IsSetInvoiceNo = false;
        }
    }
    [Serializable]
    public class InvoiceWS
    {
        /// <summary>
        /// Loại Hoá đơn: luôn là 1	(Hóa đơn giá trị gia tăng)
        /// </summary>
        public int InvoiceTypeID { get; set; }
        /// <summary>
        /// Ngày trên Hoá đơn
        /// </summary>
        public DateTime InvoiceDate { get; set; }
        /// <summary>
        /// Tên người mua hàng
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// Mã số thuế Người mua hàng
        /// </summary>
        public string BuyerTaxCode { get; set; }
        /// <summary>
        /// Tên đơn vị mua hàng
        /// </summary>
        public string BuyerUnitName { get; set; }
        /// <summary>
        /// Địa chỉ đơn vị mua hàng
        /// </summary>
        public string BuyerAddress { get; set; }
        /// <summary>
        /// Thông tin tài khoản ngân hàng người mua ví dụ: 11111111111 - BIDV chi nhánh Tây Hồ
        /// </summary>
        public string BuyerBankAccount { get; set; }
        /// <summary>
        /// Hình thức thanh toán: 1	Tiền mặt (mặc định), 2	Chuyển khoản, 3	Tiền mặt/Chuyển khoản, 4	Xuất hàng cho chi nhánh, 5	Hàng biếu tặng
        /// </summary>
        public int PayMethodID { get; set; }
        /// <summary>
        /// Hình thức nhận Hoá đơn: 1	Email , 2	Tin nhắn, 3	Email và tin nhắn, 4	Chuyển phát nhanh
        /// </summary>
        public int ReceiveTypeID { get; set; }
        /// <summary>
        /// eMail nhận Hoá đơn
        /// </summary>
        public string ReceiverEmail { get; set; }
        /// <summary>
        /// Số điện thoại nhận Hoá đơn
        /// </summary>
        public string ReceiverMobile { get; set; }
        /// <summary>
        /// Địa chỉ nhận Hoá đơn (Hoá đơn in chuyển đổi)
        /// </summary>
        public string ReceiverAddress { get; set; }
        /// <summary>
        /// Tên người nhận Hoá đơn (Hoá đơn in chuyển đổi)
        /// </summary>
        public string ReceiverName { get; set; }
        /// <summary>
        /// Ghi chú Hoá đơn
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Mã ID chứng từ kế toán hoặc số Bill code của Hoá đơn Bán hàng
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// ID tiền tệ: VND	- Việt Nam đồng (mặc định), USD - Đô la Mỹ, EUR - Đồng Euro, GBP - Bảng Anh, CNY - Nhân dân tệ,CHF - Phơ răng Thuỵ Sĩ ...
        /// </summary>
        public string CurrencyID { get; set; }
        /// <summary>
        /// Tỷ giá ngoại tệ so với VND: mặc định là 1
        /// </summary>
        public double ExchangeRate { get; set; }
        /// <summary>
        /// ID hệ thống tự sinh dùng để giao tiếp giữa các hệ thống
        /// </summary>
        public Guid InvoiceGUID { get; set; }
        /// <summary>
        /// Trạng thái của hóa đơn
        /// </summary>
        public int InvoiceStatusID { get; set; }
        /// <summary>
        /// Số hóa đơn
        /// </summary>
        public int InvoiceNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceSerial { get; set; }
        /// <summary>
        /// Mã tra cứu
        /// </summary>
        public string InvoiceCode { get; set; }
        /// <summary>
        /// Ngày ký
        /// </summary>
        public DateTime SignedDate { get; set; }
    }
    [Serializable]
    public class InvoiceDetailsWS
    {
        /// Tên hàng hóa, dịch vụ hoặc nội dung giảm giá chiết khấu (IsDiscount = 1)
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Đơn vị tính hàng hóa, dịch vụ
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// Số lượng hàng hóa dịch vụ
        /// </summary>
        public double Qty { get; set; }
        /// <summary>
        /// Giá của hàng hóa
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Thành tiền hàng hóa dịch vụ hoặc số tiền chiết khấu
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// ID thuế suất: 1	0%, 2	5%, 3	10%, 4	Không chịu thuế, 5	Không kê khai thuế
        /// </summary>
        public int TaxRateID { get; set; }
        /// <summary>
        /// Thành tiền thuế
        /// </summary>
        public double TaxAmount { get; set; }
        /// <summary>
        /// Là chiết khấu ghi trên Hoá đơn: 1 - là chiết khấu, mặc định là 0 
        /// </summary>
        public bool IsDiscount { get; set; }
    }

    [Serializable()]
    public class Result
    {
        public const int Ok = 0;
        public const int Error = 1;

        public int Status { get; set; }
        public object Object { get; set; }

        public bool isOk
        {
            get { return Status == Result.Ok; }
        }
        public bool isError
        {
            get { return Status == Result.Error; }
        }
    }
    [Serializable()]
    public class HistoryLog
    {

        public DateTime CreateDate { get; set; }
        public long ID { get; set; }
        public string IP { get; set; }
        public string LogContent { get; set; }
        public Guid ObjectGUID { get; set; }
        public int UserID { get; set; }
    }
    public class Status
    {
        public const int Error = 1;
        public const int OK = 0;

    }

    public class SecurityData
    {
        public SecurityData()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <author>
        /// Bkav Corp. - [BPTHT]
        /// Project: [SVNLog]
        /// Create Date : [2015-11-11]
        /// Author      : [CuongHMb]
        /// </author>
        /// <summary>
        /// Hàm mã hóa
        /// </summary>
        /// <param name="enObject"></param>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string EncryptToBase64String(object enObject, string key, out string result)
        {
            return EncryptToBase64String(enObject, key, true, out result);
        }
        public static string EncryptToBase64String(object enObject, string key, bool useHashing, out string result)
        {
            string msg = "";
            result = "";
            try
            {
                msg = Encrypt(enObject, key, useHashing, out result);
                if (msg.Length > 0) return msg;

                result = Convert.ToBase64String(Encoding.UTF8.GetBytes(result));
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public static string Encrypt(object enObject, string key, bool useHashing, out string result)
        {
            result = null;
            string msg = "";
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(Convertor.ObjectToBase64String(enObject));

                if (useHashing)
                {
                    using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider())
                    {
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                        hashmd5.Clear();
                    }
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform cTransform = tdes.CreateEncryptor())
                    {
                        byte[] resultArray =
                          cTransform.TransformFinalBlock(toEncryptArray, 0,
                          toEncryptArray.Length);
                        tdes.Clear();
                        result = Convert.ToBase64String(resultArray, 0, resultArray.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }


        /// <author>
        /// Bkav Corp. - [BPTHT]
        /// Project: [SVNLog]
        /// Create Date : [2015-11-11]
        /// Author      : [CuongHMb]
        /// </author>
        /// <summary>
        /// Hàm giải mã
        /// </summary>
        /// <param name="cipherString"></param>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string DecryptFromBase64String(string cipherString, string key, out object result)
        {
            return DecryptFromBase64String(cipherString, key, true, out result);
        }
        public static string DecryptFromBase64String(string cipherString, string key, bool useHashing, out object result)
        {
            string msg = "";
            result = "";
            try
            {
                msg = Decrypt(Encoding.UTF8.GetString(Convert.FromBase64String(cipherString)), key, useHashing, out result);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public static string Decrypt(string cipherString, string key, bool useHashing, out object result)
        {
            result = null;
            string msg = "";
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                if (useHashing)
                {
                    using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider())
                    {
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                        hashmd5.Clear();
                    }
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform cTransform = tdes.CreateDecryptor())
                    {
                        byte[] resultArray = cTransform.TransformFinalBlock(
                                             toEncryptArray, 0, toEncryptArray.Length);
                        tdes.Clear();
                        result = Convertor.Base64StringToObject(UTF8Encoding.UTF8.GetString(resultArray));
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

    }
    static public class Convertor
    {
        static public string JsonToObject<T>(object data, out T obj) where T : class
        {
            obj = default(T);

            try
            {
                obj = JsonConvert.DeserializeObject<T>(Convert.ToString(data));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        static public string ObjectToJson(object obj, out string value)
        {
            value = "";
            try
            {
                value = JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        /// <summary>
        /// Serialize và chuyển sang Base64 1 object bất kỳ (object cần có thuộc tính Serializable)
        /// </summary>
        /// <param name="obj">object cần chuyển sang Base64</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ObjectToBase64String(object obj, out string value)
        {
            string msg = "";
            value = null;

            if (obj == null) return "Error: Object is null @ObjectToBase64String";

            try
            {
                value = ObjectToBase64String(obj);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        public static string ObjectToBase64String(object obj)
        {
            if (obj == null) return null;

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>
        /// Deserialize từ Base64 về object 
        /// </summary>
        /// <param name="base64">Chuỗi cần chuyển về object</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Base64StringToObject(string base64, out object value)
        {
            string msg = "";
            value = null;

            try
            {
                value = Base64StringToObject(base64);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        public static object Base64StringToObject(string base64)
        {
            byte[] arrBytes = Convert.FromBase64String(base64);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream())
            {
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                object obj = bf.Deserialize(memStream);
                return obj;
            }
        }

        static public string StringtoGuid(string guid, out Guid value)
        {
            value = Guid.Empty;
            try
            {
                value = new Guid(guid);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "";
        }
        static public Guid ToGuid(object obj, Guid defaultValue)
        {
            try
            {
                return Guid.Parse(obj.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        static public string StringtoNumber(string s, out long value)
        {
            value = 0;
            try
            {
                value = long.Parse(s);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "";
        }
        static public long ToNumber(object obj, long defaultvalue)
        {
            try
            {
                return Convert.ToInt64(obj);
            }
            catch
            {
                return defaultvalue;
            }
        }

        static public string StringtoNumber(string s, out int value)
        {
            value = 0;
            try
            {
                value = int.Parse(s);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "";
        }
        static public int ToNumber(object obj, int defaultvalue)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                return defaultvalue;
            }
        }

        static public string StringtoDatetime(string s, out double value)
        {
            value = 0;
            try
            {
                value = double.Parse(s);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "";
        }
        static public string StringtoDatetime(string s, out DateTime value)
        {
            value = DateTime.MinValue;
            try
            {
                value = DateTime.Parse(s);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "";
        }

        static public string ToString(object obj, string defaultvalue)
        {
            try
            {
                return Convert.ToString(obj);
            }
            catch
            {
                return defaultvalue;
            }
        }
        static public bool ToBoolean(object obj, bool defaultvalue)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch
            {
                return defaultvalue;
            }
        }
    }

}
