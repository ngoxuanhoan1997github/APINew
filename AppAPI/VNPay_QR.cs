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
        private const string VnpayApiUrl2 = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
        string secretKey = "QVU13R4JBHMR1M4JWJ0CBN0CBUISMQBK";
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
        public string Checksum()
        {
            string dataToHash = secretKey+ "order-62 | toet | N0B3T9UT | FTI | 234000 | https://vnpay.vn/success | https://vnpay.vn/cancel | HNPMC25702 | FTI_PE4019B260249_QR_CODE | VNPAY_QRCODE | 234000"; // Dữ liệu cần băm
            // Tính toán checksum
            string checksum = CalculateChecksum(dataToHash);
            // In ra kết quả checksum
            return checksum;
        }
        public static string CalculateChecksum(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert dữ liệu từ string sang byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                // Chuyển byte array sang string hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Format byte thành hex
                }
                return builder.ToString();
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
            
            DateTime dateTime = DateTime.Now;
            //Lấy ngày hiện tại
            string nam = dateTime.ToString("yy");
            string thang = dateTime.Month.ToString("D2");
            string ngay = dateTime.Day.ToString("D2");

            //Lấy thời gian hiện tại
            DateTime newTime = dateTime.AddMinutes(5);
            string gio = dateTime.Hour.ToString("D2");
            string phut = newTime.Minute.ToString("D2");

            //Băm checksum
            string checksum = Checksum();

            //Giá trị đầu vào
            var apiRequest_vnpay = new APIRequest_VNPay
            {
                userId = "toet",
                checksum = checksum,
                orderCode = "order-62",
                payments = new Payments
                {
                    qr = new Qr
                    {
                        methodCode = "VNPAY_QRCODE",
                        amount = 234000,
                        qrWidth = 400,
                        qrHeight = 400,
                        qrImageType = 0,
                        customerPhone = "",
                        merchantMethodCode = "FTI_PE4019B260249_QR_CODE",
                        clientTransactionCode = "HNPMC25702"
                    }
                },
                cancelUrl = "https://vnpay.vn/cancel",
                successUrl = "https://vnpay.vn/success",
                terminalCode = "DEMO",
                merchantCode = "FTI",
                totalPaymentAmount = 234000,
                expiredDate = nam + thang + ngay + gio + phut
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
