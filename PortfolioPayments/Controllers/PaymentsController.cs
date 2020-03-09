using PortfolioPayments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PortfolioPayments.Controllers
{
    public class PaymentsController : ApiController
    {
        List<Payment> payments = new List<Payment>();

        public PaymentsController()
        {
            payments.Add(new Payment { paymentId = 1, portfolioId = 100, amount = 100000, currency = "USD", paymentDate = DateTime.Today, settled = true });
            payments.Add(new Payment { paymentId = 2, portfolioId = 100, amount = 200000, currency = "USD", paymentDate = DateTime.Today, settled = true });
            payments.Add(new Payment { paymentId = 3, portfolioId = 110, amount = 300000, currency = "EUR", paymentDate = DateTime.Today, settled = true });
            payments.Add(new Payment { paymentId = 4, portfolioId = 110, amount = 250000, currency = "EUR", paymentDate = DateTime.Today, settled = true });
            payments.Add(new Payment { paymentId = 5, portfolioId = 155, amount = 1000000, currency = "GBP", paymentDate = DateTime.Today, settled = false });
            payments.Add(new Payment { paymentId = 6, portfolioId = 155, amount = 500000, currency = "GBP", paymentDate = DateTime.Today.AddDays(-100), settled = false });
            payments.Add(new Payment { paymentId = 7, portfolioId = 155, amount = 1100000, currency = "GBP", paymentDate = DateTime.Today, settled = true });
            payments.Add(new Payment { paymentId = 8, portfolioId = 110, amount = 1200000, currency = "EUR", paymentDate = DateTime.Today, settled = true });
        }

        // GET: api/Portfolio
        public List<Payment> Get()
        {
            return payments;
        }

        // GET: api/Portfolio/5
        public IEnumerable<Payment> Get(int id)
        {
            return payments.Where(p => p.portfolioId == id);
        }

    }
}
