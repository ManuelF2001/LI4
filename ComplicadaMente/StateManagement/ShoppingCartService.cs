using System;
using System.Collections.Generic;
using ComplicadaMente.Components.Models;

namespace ComplicadaMente.Services
{
    public class ShoppingCartService
    {
        private readonly List<Puzzle> _cartItems = new();

        public event Action OnChange;

        public void AddToCart(Puzzle puzzle)
        {
            _cartItems.Add(puzzle);
           NotifyStateChanged();
        }

        public void RemoveFromCart(Puzzle puzzle)
        {
            _cartItems.Remove(puzzle);
            NotifyStateChanged();
        }

        public List<Puzzle> GetCartItems()
        {
            return _cartItems;
        }

        public void ClearCart()
        {
            _cartItems.Clear();
            NotifyStateChanged();
        }

        private  void NotifyStateChanged() {  OnChange?.Invoke();  }
    }
}
