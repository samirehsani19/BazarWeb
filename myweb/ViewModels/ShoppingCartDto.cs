﻿namespace myweb.ViewModels
{
    public class ShoppingCartDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Total { get; set; }
    }
}
