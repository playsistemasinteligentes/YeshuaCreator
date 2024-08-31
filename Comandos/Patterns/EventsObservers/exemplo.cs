using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Patterns.EventsObservers
{
    //Utilize Eventos e Observadores

    public class Stock
    {
        public event EventHandler<StockLevelChangedEventArgs> StockLevelChanged;

        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            private set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnStockLevelChanged(new StockLevelChangedEventArgs(_quantity));
                }
            }
        }

        public void AddStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be positive.");

            Quantity += amount;
        }

        public void RemoveStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be positive.");

            if (amount > Quantity)
                throw new InvalidOperationException("Not enough stock.");

            Quantity -= amount;
        }

        protected virtual void OnStockLevelChanged(StockLevelChangedEventArgs e)
        {
            StockLevelChanged?.Invoke(this, e);
        }
    }

    public class StockLevelChangedEventArgs : EventArgs
    {
        public int NewQuantity { get; }

        public StockLevelChangedEventArgs(int newQuantity)
        {
            NewQuantity = newQuantity;
        }
    }



    public class StockManager
    {
        public void Subscribe(Stock stock)
        {
            stock.StockLevelChanged += OnStockLevelChanged;
        }

        private void OnStockLevelChanged(object sender, StockLevelChangedEventArgs e)
        {
            Console.WriteLine($"Stock level changed. New quantity: {e.NewQuantity}");
            // Implement additional logic, such as sending alerts or updating databases.
        }
    }



    //########################## main 
    //public static void Main_()
    //{
        //var stock = new Stock();
        //var stockManager = new StockManager();

        //// Subscribe to stock level changes
        //stockManager.Subscribe(stock);

        //// Make changes to the stock
        //stock.AddStock(100); // This will trigger the event
        //stock.RemoveStock(30); // This will trigger the event
    //}


}
