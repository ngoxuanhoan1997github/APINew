using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppAPI.Class;
using RestSharp;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;

namespace AppAPI
{
    public partial class VNPay_QR : Form
    {
        private const string VnpayApiUrl = "https://payment-gateway.vnpaytest.vn/api/v2/payment/init/multi-v2.1";
        
        public VNPay_QR()
        {
            InitializeComponent();
        }

        private void VNPay_QR_Load(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                var htmlData = client.DownloadData("https://api.vietqr.io/v2/banks");
                var bankRamJson = Encoding.UTF8.GetString(htmlData);
                var listBankData = JsonConvert.DeserializeObject<Banks>(bankRamJson);

                cbbnganhang.DataSource = listBankData.data;
                cbbnganhang.DisplayMember = "shortName";
                cbbnganhang.ValueMember = "bin";
                cbbtemplate.SelectedIndex = 0;
                cbbnganhang.SelectedIndex = 9;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        //Băm checksum
        public string Checksum(string ordercode, string userId, string terminalCode, string merchantCode, int totalPaymentAmount, string successUrl, string cancelUrl, string clientTransactionCode, string merchantMethodCode, string methodCode, int amount)
        {
            string Keysecret = "72b1dcb6c927c619df57e0cb2cb68aa9";
            string dataQrVnpay = Keysecret + ordercode + "|" + userId + "|" + terminalCode + "|" + merchantCode + "|" + totalPaymentAmount + "|" + successUrl + "|" + cancelUrl + "|" + clientTransactionCode + "|" + merchantMethodCode + "|" + methodCode + "|" + amount;
            string secretKey = Keysecret;

            string checksum = CalculateChecksum(dataQrVnpay, secretKey);
            return checksum;
        }
        public static string CalculateChecksum(string data, string secretKey)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secretKey);
            byte[] inputBytes = Encoding.UTF8.GetBytes(data);

            using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(inputBytes);
                string base64Checksum = Convert.ToBase64String(hashBytes);

                Console.WriteLine("Input String: " + data);
                Console.WriteLine("HMAC SHA-256 Checksum (Base64): " + base64Checksum);
                return base64Checksum;
            }
        }
        private void btnQRcode_Click(object sender, EventArgs e)
        {
            var apiRequest = new APIRequest();
            apiRequest.acqId = Convert.ToInt32(cbbnganhang.SelectedValue.ToString());
            //apiRequest.acqId = 970445;
            apiRequest.accountNo = txtstk.Text;
            apiRequest.accountName = txttentk.Text;
            apiRequest.amount = Convert.ToInt32(txtsotien.Text);
            apiRequest.format = "Text";
            apiRequest.template = cbbtemplate.Text.ToString();
            apiRequest.addInfo = txtnoidung.Text;
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);

            //use restsharp for request api
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<APIReponse>(content);
            var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
            pictureBox1.Image = image;
        }

        private void btnCreateQRVNPAY_Click(object sender, EventArgs e)
        {
            string orderCode = "VNP20220819000032";
            string userID = "userId";
            string terminalCode = "PE1118CC51277";
            string merchantCode = "VNPAY_TEST";
            int totalPaymentAmount = 33000;
            string successUrl = "https://vnpay.vn/success";
            string cancelUrl = "https://vnpay.vn/cancel";
            string clientTransactionCode = orderCode + "1198";
            string merchantMethodCode = "VNPAY_TEST_PE1118CC51277_QRCODE";
            string methodCode = "VNPAY_QRCODE";
            int amount = 33000;

            DateTime dateTime = DateTime.Now;
            //Lấy ngày hiện tại
            string nam = dateTime.ToString("yy");
            string thang = dateTime.Month.ToString("D2");
            string ngay = dateTime.Day.ToString("D2");

            //Lấy thời gian hiện tại
            DateTime newTime = dateTime.AddMinutes(15);
            string gio = dateTime.Hour.ToString("D2");
            string phut = newTime.Minute.ToString("D2");

            //Giá trị đầu vào
            var apiRequest_vnpay = new APIRequest_VNPay
            {
                userId = userID,
                checksum = Checksum(orderCode,userID,terminalCode,merchantCode,totalPaymentAmount,successUrl,cancelUrl,clientTransactionCode, merchantMethodCode, methodCode, amount),
                orderCode = orderCode,
                payments = new Payments
                {
                    qr = new Qr
                    {
                        methodCode = methodCode,
                        amount = amount,
                        qrWidth = 400,
                        qrHeight = 400,
                        qrImageType = 0,
                        customerPhone = "0334246837",
                        merchantMethodCode = merchantMethodCode,
                        clientTransactionCode = orderCode + "1011"
                    }
                },
                successUrl = successUrl,
                cancelUrl = cancelUrl,
                terminalCode = terminalCode,
                merchantCode = merchantCode,
                totalPaymentAmount = totalPaymentAmount,
                expiredDate = $"{nam}{thang}{ngay}{gio}{phut}"
            };

            var jsonRequest = JsonConvert.SerializeObject(apiRequest_vnpay);

            //use restsharp for request api
            var client = new RestClient(VnpayApiUrl);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<APIResponse_VNPay>(content);
        }
    }
}
