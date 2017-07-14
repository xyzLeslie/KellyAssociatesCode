using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Repository;
using System.Net.Mail;

namespace ShoppingCart.Service.Services
{
    public interface IOrderService
    {
        bool ProcessOrder(Order order);
    }
    public class OrderService:IOrderService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IPaymentService _paymentService;
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;

        public OrderService(IInventoryRepository inventoryRepository,IPaymentService paymentService, 
            IOrderRepository orderRepository, IEmailService emailService)
        {
            _inventoryRepository = inventoryRepository;
            _paymentService = paymentService;
            _orderRepository = orderRepository;
            _emailService = emailService;
        }
        
        public bool ProcessOrder(Order order)
        {
            
            if (_inventoryRepository.CheckInventory(order.Item.ProductID, order.Quantity))
            {
                if (_paymentService.ChargePayment(order.CardInfo.creditCardNumber, order.CardInfo.amount))
                {
                    _orderRepository.AddOrder(order);

                    StringBuilder body = new StringBuilder();
                    body.AppendLine("A new order has been submitted");
                    EmailSettings emailSettings = new EmailSettings();
                    MailMessage mailMessage = new MailMessage(
                                           emailSettings.MailFromAddress,
                                           emailSettings.MailToAddress,
                                           "New order submitted!",
                                           body.ToString());
                    _emailService.SendEmail(mailMessage);

                    return true;
                }
                else
                {
                    throw new Exception("Payment Declined");
                }
            }
            else
            {
                throw new Exception("The ordered Qunatity is not available"); 
            }
        }

        

        public void Delete_Order(Order order)
        {
            if (!ProcessOrder(order))
            {
                _orderRepository.DeleteOrder(order);
            }
        }


    }
}
