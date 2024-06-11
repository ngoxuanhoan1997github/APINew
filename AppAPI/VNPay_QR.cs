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

namespace AppAPI
{
    public partial class VNPay_QR : Form
    {
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
            apiRequest.amount =Convert.ToInt32(txtsotien.Text);
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
            //var api_vnpay = new API_VNPay();
            //api_vnpay.userId = "userId";
            //api_vnpay.checksum = "b7eaae2265fada2d6e0dd1ad8429bbad0eec85f5867d3f0c101a19385d777dc6";
            //api_vnpay.orderCode = "VNP20220819000001";
            //api_vnpay.payments.qr.methodCode = "VNPAY_QRCODE";
            //api_vnpay.payments.qr.amount = 33000;
            //api_vnpay.payments.qr.qrWidth = 0;
            //api_vnpay.payments.qr.qrHeight = 0;
            //api_vnpay.payments.qr.qrImageType = 0;
            //api_vnpay.payments.qr.customerPhone = "1234567890";
            //api_vnpay.payments.qr.merchantMethodCode = "VNPAY_TEST_PE1118CC51277_QRCODE";
            //api_vnpay.payments.qr.clientTransactionCode = "HNPMC25702";
            //api_vnpay.cancelUrl = "https://vnpay.vn/cancel";
            //api_vnpay.successUrl = "https://vnpay.vn/success";
            //api_vnpay.terminalCode = "PE1118CC51277";
            //api_vnpay.merchantCode = "VNPAY_TEST";
            //api_vnpay.totalPaymentAmount = 33000;
            //api_vnpay.expiredDate = "2111050834";

            var api_vnpay = new API_VNPay
            {
                userId = "userId",
                checksum = "b7eaae2265fada2d6e0dd1ad8429bbad0eec85f5867d3f0c101a19385d777dc6",
                orderCode = "VNP20220819000001",
                payments = new Payments
                {
                    qr = new Qr
                    {
                        methodCode = "VNPAY_QRCODE",
                        amount = 33000,
                        qrWidth = 0,
                        qrHeight = 0,
                        qrImageType = 0,
                        customerPhone = "1234567890",
                        merchantMethodCode = "VNPAY_TEST_PE1118CC51277_QRCODE",
                        clientTransactionCode = "HNPMC25702"
                    }
                },
                cancelUrl = "https://vnpay.vn/cancel",
                successUrl = "https://vnpay.vn/success",
                terminalCode = "PE1118CC51277",
                merchantCode = "VNPAY_TEST",
                totalPaymentAmount = 33000,
                expiredDate = "2111050834"
            };
            var jsonRequest = JsonConvert.SerializeObject(api_vnpay);

            var client = new RestClient("https://sandbox.vnpayment.vn/merchant_webapi/api/transaction");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<APIReponse>(content);
        }
    }
}
