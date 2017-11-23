using System;
using System.Collections.Generic;
using ECommerce.Domain.Enums;
using System.Linq;

namespace ECommerce.Domain.Entities
{
    public class Order
    {
        private IList<OrderItem> _orderItems;
        public EOrderStatus Status { get; set; }

        public Order(IList<OrderItem> orderItems, int userId)
        {
            this.Date = DateTime.Now;
            this._orderItems = new List<OrderItem>();
            orderItems.ToList().ForEach(x => AddItem(x));
            this.UserId = userId;
            this.Status = EOrderStatus.Created;
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public ICollection<OrderItem> OrderItems
        {
            get { return _orderItems; }
            private set { _orderItems = new List<OrderItem>(value); }
        }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in _orderItems)
                    total += (item.Price * item.Quantity);

                return total;
            }
        }

        public void AddItem(OrderItem item)
        {
            _orderItems.Add(item);
        }
    }
}