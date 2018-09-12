using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Emart
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            cart.Display();
            cart.Shopping();
               
        }    
       
    }
    class Cart
    {
        public Dictionary<int, Product> product = new Dictionary<int, Product>();
        public Cart()
        {
           
        }
        public void Display()
        {
            GroceryProduct groceryItem1 = new GroceryProduct("cake", 20);
            GroceryProduct groceryItem2 = new GroceryProduct("biscuit", 10);
            GroceryProduct groceryItem3 = new GroceryProduct("cola", 3);
            GroceryProduct groceryItem4 = new GroceryProduct("chip", 5);
            GroceryProduct groceryItem5 = new GroceryProduct("meat", 15);
            CosmeticProduct cosmeticItem1 = new CosmeticProduct("Makeup", 100);
            CosmeticProduct cosmeticItem2 = new CosmeticProduct("Eyeshadow", 50);
            CosmeticProduct cosmeticItem3 = new CosmeticProduct("Lip Balm", 30);
            CosmeticProduct cosmeticItem4 = new CosmeticProduct("Eyeliner", 25);
            CosmeticProduct cosmeticItem5 = new CosmeticProduct("Foundation", 35);
            VegetableProduct vegetableItem1 = new VegetableProduct("potato", 5);
            VegetableProduct vegetableItem2 = new VegetableProduct("tomato", 6);
            VegetableProduct vegetableItem3 = new VegetableProduct("onion", 1);
            VegetableProduct vegetableItem4 = new VegetableProduct("broccoli", 3);
            VegetableProduct vegetableItem5 = new VegetableProduct("beans", 8);
            MilkProduct milkItem1 = new MilkProduct("yogurt", 2.5);
            MilkProduct milkItem2 = new MilkProduct("Ice cream", 5.5);
            MilkProduct milkItem3 = new MilkProduct("cheese", 5);
            MilkProduct milkItem4 = new MilkProduct("butter", 4);
            MilkProduct milkItem5 = new MilkProduct("milk", 3);
            product.Add(1, groceryItem1);
            product.Add(2, groceryItem2);
            product.Add(3, groceryItem3);
            product.Add(4, groceryItem4);
            product.Add(5, groceryItem5);
            product.Add(6, cosmeticItem1);
            product.Add(7, cosmeticItem2);
            product.Add(8, cosmeticItem3);
            product.Add(9, cosmeticItem4);
            product.Add(10, cosmeticItem5);
            product.Add(11, vegetableItem1);
            product.Add(12, vegetableItem2);
            product.Add(13, vegetableItem3);
            product.Add(14, vegetableItem4);
            product.Add(15, vegetableItem5);
            product.Add(16, milkItem1);
            product.Add(17, milkItem2);
            product.Add(18, milkItem3);
            product.Add(19, milkItem4);
            product.Add(20, milkItem5);
            ArrayList akeys = new ArrayList(product.Keys);
            akeys.Sort();
            Console.WriteLine("---------------Product List-------------");
            foreach (int skey in akeys)
            {
                Console.WriteLine("ID:{0,-6} {1}", skey, product[skey]);
            }
           
        }
        public void Shopping()
        {
            try
            {
                
                string input;
                int ID;
                int Quantity;
                int[] Index = new int[20];
                double[] Amount = new double[20];
                do
                {

                    Console.WriteLine("---------------");
                    Console.WriteLine("please enter product id: ");
                    input = Console.ReadLine();
                    ID = int.Parse(input) - 1;
                    Console.WriteLine("please enter quantity: ");
                    input = Console.ReadLine();
                    Quantity = int.Parse(input);
                    Index[ID] = Index[ID] + Quantity;
                    Console.WriteLine("please enter  'check' if you finished, enter'y' if you wanna continue");
                    input = Console.ReadLine();
                }
                while (input != "check");

                Console.WriteLine("---------------Invoice-------------");
                for (int i = 0; i < 20; i++)
                {
                    if (Index[i] != 0)
                    {
                        Amount[i] = product[i + 1].Price * Index[i]*(1+ product[i + 1].Tax)*(1- product[i + 1].Dis);
                        Console.WriteLine("Product ID:{0,-4} {1} Quantity:{2,-4} Tax:{3,-10} Discount:{4,-4} Amount:{5,-4}", i + 1, product[i + 1],Index[i],product[i+1].Tax,product[i+1].Dis,Amount[i]);
                        
                    }
                }
                double Total = 0;
                foreach(double j in Amount)
                {
                    Total += j;
                }
                Console.WriteLine("----Total Price is:" + Total);

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
        }

    }

    class Product
    {
        public string Name;
        public double Price;
        public double Tax;
        public double Dis;
        public Product(string n,double p)
        {
            Name = n;
            Price = p;
        }
    }
    class GroceryProduct : Product
    {
        
        public GroceryProduct(string n,double p) : base(n, p)
        {
            Tax = 0.05;
            Dis = 0;
        }
        public override string ToString()
        {
            return string.Format("name:{0,-10}   price:{1,-10}", Name, Price);
        }
    }
    class CosmeticProduct : Product
    {
      
        public CosmeticProduct(string n, double p) : base(n, p)
        {
            Tax = 0.15;
            Dis = 0.05;

        }
        public override string ToString()
        {
            return string.Format("name:{0,-10}   price:{1,-10}", Name, Price);
        }
    }
    class VegetableProduct : Product
    {
     
        public VegetableProduct(string n, double p) : base(n, p)
        {
             Tax = 0;
             Dis = 0;

        }
        public override string ToString()
        {
            return string.Format("name:{0,-10}   price:{1,-10}", Name, Price);
        }
    }
    class MilkProduct : Product
    {
      
        public MilkProduct(string n, double p) : base(n, p)
        {
             Tax = 0.1;
             Dis = 0.05;
        
        }
        public override string ToString()
        {
            return string.Format("name:{0,-10}   price:{1,-10}", Name, Price);
        }
    }

}
