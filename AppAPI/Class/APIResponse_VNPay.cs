using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Class
{
    public class APIResponse_VNPay
    {
        public string code { get; set; }
        public string message { get; set; }
        public string orderCode { get; set; }
        public Payments payments { get; set; }
        public string paymentRequestId { get; set; }
    }
}
