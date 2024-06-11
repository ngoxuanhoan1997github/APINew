using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Class
{
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

    public class API_VNPay
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
}
