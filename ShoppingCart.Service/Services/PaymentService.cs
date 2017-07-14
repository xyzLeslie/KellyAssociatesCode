using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Repository;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ShoppingCart.Service.Services
{
    public interface IPaymentService
    {
        bool ChargePayment(string creditCardNumber, decimal amount);
    }

    public class PaymentService:IPaymentService
    {
        public bool ChargePayment(string creditCardNumber, decimal amount)
        {
            if (!string.IsNullOrWhiteSpace(creditCardNumber) && amount > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://ThirdPartyPayment");

                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/##").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
            else
            {
                return false;
            }
        }
    }
}
