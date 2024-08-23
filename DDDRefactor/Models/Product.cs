using CSharpFunctionalExtensions;
using DDDRefactor.Enums;

namespace DDDRefactor.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; private set; }

        public string ProductSheme { get; private set; }

        public int Amount { get; private set; }

        public double Price { get; private set;  }

        public CurrencyType СurrencyType { get; private set; }

        public string? ProductInfo { get; private set; }

        public ICollection<RequestMember>? RequestMembers { get; private set; }

        /// <summary>
        /// Дата запуска в производство
        /// </summary>
        public DateTime StartProduction { get; private set; }// = DateTime.Now;

        /// <summary>
        /// Требуемая дата окончания производства
        /// </summary>
        public DateTime EndProduction { get; private set; }// = DateTime.Now.AddDays(10);

        /// <summary>
        /// Требуемая дата поставки
        /// </summary>
        public DateTime DeliveryDate { get; private set; }// = DateTime.Now.AddDays(15);

        /// <summary>
        /// Дата отгрузки по договору
        /// </summary>
        public DateTime SendingDate { get; private set; }// = DateTime.Now.AddDays(20);

        /// <summary>
        /// Дата поставки по договору
        /// </summary>
        public DateTime FactOfDeliveryDate { get; private set; }// = DateTime.Now.AddDays(25);

        public byte Prepayment { get; private set; } //- поле аванс в %
        public DateTime PrepaymentaDate  { get; private set; }//- поле дата аванса
        public DateTime FullPaymentDate  { get; private set; }//- поле полной оплаты

        private Product()
        {
            
        }
        private Product(
            string productName, string productSheme, int amount,
            double price, CurrencyType сurrencyType, string? productInfo,
            ICollection<RequestMember>? requestMembers, DateTime startProduction,
            DateTime endProduction, DateTime deliveryDate, DateTime sendingDate,
            DateTime factOfDeliveryDate, byte prepayment, 
            DateTime prepaymentaDate, DateTime fullPaymentDate)
        {
            ProductName = productName;
            ProductSheme = productSheme;
            Amount = amount;
            Price = price;
            СurrencyType = сurrencyType;
            ProductInfo = productInfo;
            RequestMembers = requestMembers;
            StartProduction = startProduction;
            EndProduction = endProduction;
            DeliveryDate = deliveryDate;
            SendingDate = sendingDate;
            FactOfDeliveryDate = factOfDeliveryDate;
            Prepayment = prepayment;
            PrepaymentaDate = prepaymentaDate;
            FullPaymentDate = fullPaymentDate;
        }

        public static Result<Product, string[]> Create(
            string productName, string productSheme, int amount,
            double price, CurrencyType сurrencyType, string? productInfo,
            ICollection<RequestMember>? requestMembers, DateTime startProduction,
            DateTime endProduction, DateTime deliveryDate, DateTime sendingDate,
            DateTime factOfDeliveryDate, byte prepayment,
            DateTime prepaymentaDate, DateTime fullPaymentDate)
        {
            return new Product(productName, productSheme, amount, 
                price, сurrencyType, productInfo, requestMembers,
                startProduction, endProduction, deliveryDate,
                sendingDate, factOfDeliveryDate, prepayment, 
                prepaymentaDate, fullPaymentDate);
        }
    }
}