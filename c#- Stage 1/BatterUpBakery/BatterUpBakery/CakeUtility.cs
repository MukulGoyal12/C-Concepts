namespace BatterUpBakery //Do not change the namespace name
{
    public class CakeUtility    //Do not change the class name
    {
        //Implement the code here
        public void AddCakeDetails(string flavour, int quantity, double price)
        {
            Program.CakeList.Add(new Cake() { Flavour = flavour, Quantity = quantity, Price = price });
        }

        public Dictionary<string, double> GetCakePrice(string flavour)
        {
            Dictionary<string, double> cakeDic = new Dictionary<string, double>();
            Cake found = null;
            foreach (Cake cake in Program.CakeList)
            {
                if (cake.Flavour == flavour)
                {
                    found = cake;
                    break;
                }
            }
            if (found != null)
            {
                cakeDic.Add(found.Flavour, found.Price);
            }
            return cakeDic;
        }

        public List<string> RemoveCakeDetails(string flavour)
        {
            List<string> ls = new List<string>();
            Cake found = null;

            foreach (Cake cake in Program.CakeList)
            {
                if (cake.Flavour == flavour)
                {
                    found = cake;
                }
                else
                {
                    ls.Add(cake.Flavour);
                }
            }

            if (found != null)
            {
                Program.CakeList.Remove(found); 
            }

            return ls;
        }


    }
}