using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentManager
{
    public class Payment
    {
        public int paymentId { get; set; }
        public int portfolioId { get; set; }
        public string currency { get; set; }
        public float amount { get; set; }
        public DateTime paymentDate { get; set; }
        public bool settled { get; set; }

    }
}