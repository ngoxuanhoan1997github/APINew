using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Class
{
    //Request
    public class Qr
    {
        public string methodCode { get; set; }
        public int amount { get; set; }
        public int qrWidth { get; set; }
        public int qrHeight { get; set; }
        public int qrImageType { get; set; }
        public string customerPhone { get; set; }
        public string merchantMethodCode { get; set; }
        public string clientTransactionCode { get; set; }
    }

    public class Payments
    {
        public Qr qr { get; set; }
    }

    public class APIRequest_VNPay
    {
        public string userId { get; set; }
        public string checksum { get; set; }
        public string orderCode { get; set; }
        public Payments payments { get; set; }
        public string cancelUrl { get; set; }
        public string successUrl { get; set; }
        public string terminalCode { get; set; }
        public string merchantCode { get; set; }
        public int totalPaymentAmount { get; set; }
        public string expiredDate { get; set; }
    }

    //Reponse
    public class Qrr
    {
        public string clientTransactionCode { get; set; }
        public string transactionCode { get; set; }
        public string methodCode { get; set; }
        public string amount { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string qrContent { get; set; }
        public string returnUrl { get; set; }
        public string traceId { get; set; }
        public string partnerResponseCode { get; set; }
        public object postData { get; set; }
        public string merchantAddress { get; set; }
        public int qrType { get; set; }
        public object partnerAppCode { get; set; }
        public object partnerRequestRef { get; set; }
    }

    public class Paymentss
    {
        public object credit { get; set; }
        public object loyalty { get; set; }
        public Qrr qrr { get; set; }
        public object card { get; set; }
        public object installment { get; set; }
        public object crypto { get; set; }
    }
    public class APIResponse_VNPay
    {
        public string code { get; set; }
        public string message { get; set; }
        public string orderCode { get; set; }
        public Paymentss paymentss { get; set; }
        public string paymentRequestId { get; set; }
    }
}
