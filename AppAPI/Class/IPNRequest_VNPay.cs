using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Class
{
    public class IPNRequest_VNPay
    {
        public int amount { get; set; }
        public string bankCode { get; set; }
        public string checksum { get; set; }
        public string cashierId { get; set; }
        public string orderCode { get; set; }
        public int totalPaid { get; set; }
        public string methodCode { get; set; }
        public int realAmount { get; set; }
        public string partnerCode { get; set; }
        public string merchantCode { get; set; }
        public string responseCode { get; set; }
        public string bankAccountNo { get; set; }
        public int installmentTerm { get; set; }
        public string responseMessage { get; set; }
        public string transactionCode { get; set; }
        public string merchantMethodCode { get; set; }
        public string clientTransactionCode { get; set; }
        public string partnerTransactionCode { get; set; }
        public string extraData { get; set; }
    }
    public class IPNReponse_VNPay
    {
        public string code { get; set; }
        public string message { get; set; }
        public string traceId { get; set; }
    }
}
