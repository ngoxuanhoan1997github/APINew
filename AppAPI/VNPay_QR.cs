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
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace AppAPI
{
    public partial class VNPay_QR : Form
    {
        private const string VnpayApiUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
        private const string MerchantId = "N0B3T9UT";
        private const string AccessKey = "QVU13R4JBHMR1M4JWJ0CBN0CBUISMQBK";
        private const string SecretKey = "QVU13R4JBHMR1M4JWJ0CBN0CBUISMQBK";
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

        private async void btnCreateQRVNPAY_Click(object sender, EventArgs e)
        {
            try
            {
                // Create payment request and get QR code data from VNPAY API
                string qrData = await CreatePaymentRequestAsync(100.0, "ORDER123");

                if (!string.IsNullOrEmpty(qrData))
                {
                    // Generate QR code image from data
                    Bitmap qrCodeImage = GenerateQRCode(qrData);

                    // Display QR code image
                    pictureBox2.Image = qrCodeImage;
                }
                else
                {
                    MessageBox.Show("Failed to generate QR code.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async Task<string> CreatePaymentRequestAsync(double amount, string orderId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var paymentRequest = new
                {
                    merchantId = MerchantId,
                    amount = amount,
                    orderId = orderId,
                    orderInfo = "Payment for order #" + orderId,
                    returnUrl = "YOUR_RETURN_URL"
                    // Add other required parameters
                };

                var requestContent = new StringContent(JsonConvert.SerializeObject(paymentRequest), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(VnpayApiUrl, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle error response
                    return null;
                }
            }
        }
        private Bitmap GenerateQRCode(string qrData)
        {
            QRCodeWriter qrCodeWriter = new QRCodeWriter();
            BitMatrix qrBitMatrix = qrCodeWriter.encode(qrData, BarcodeFormat.QR_CODE, 300, 300);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            return barcodeWriter.Write(qrBitMatrix);
        }
    }
}
