namespace Task3
{
    internal class OnlineStore
    {
        private List<ICustomer> customers = new List<ICustomer>();
        public void Subscribe(ICustomer customer)
        {
            customers.Add(customer);
        }
        public void Unsubscribe(ICustomer customer)
        {
            customers.Remove(customer);
        }
        public void AnnounceDiscount(string discountInfo)
        {
            Console.WriteLine($"Новая скидка — {discountInfo}");
            NotifyCustomers(discountInfo);
        }
        private void NotifyCustomers(string discountInfo)
        {
            foreach (var customer in customers)
            {
                customer.Update(discountInfo);
            }
        }
    }
}
