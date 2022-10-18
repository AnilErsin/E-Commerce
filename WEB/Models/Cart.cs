using System.Collections.Generic;
using System.Linq;

namespace WEB.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();



        public List<CartItem> MyCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void AddItem(CartItem item)//chai 18
        {
            if (_myCart.ContainsKey(item.Id))
            {
                _myCart[item.Id].Quantity += 1;
                return;
            }
            _myCart.Add(item.Id, item);
        }

    }
}
