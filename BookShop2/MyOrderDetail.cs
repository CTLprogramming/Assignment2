﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2
{
    internal class MyOrderDetail
    {
        public long iSBN;
        private int quantity, stock;
        private decimal price;
        private string title, authorForename, authorSurname;
        
        public MyOrderDetail() 
        {
            this.iSBN = 0; this.quantity = 0; this.stock = 0; this.price = 0; this.title = string.Empty; this.authorForename = string.Empty; this.authorSurname = string.Empty;
        }
        public MyOrderDetail(long iSBN, int quantity, int stock,decimal price, string title, string authorForename, string authorSurname)
        {
            this.iSBN = iSBN;
            this.quantity = quantity;
            this.stock = stock;
            this.price = price;
            this.title = title;
            this.authorForename = authorForename;
            this.authorSurname = authorSurname;
        }
        public long ISBN
        {
            get { return this.iSBN;}
            set { this.iSBN = value;}
        }
        public int Quantity
        {
            get { return this.quantity;}
            set
            {
                this.quantity = value;
            }
        }
        public int Stock
        {
            get { return this.stock;}
            set { this .stock = value;} 
        }
        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public string AuthorForename
        {
            get { return this.authorForename; }
            set { this.authorForename = value; }
        }
        public string AuthorSurname
        {
            get { return this.authorSurname; }
            set { this.authorSurname = value; }
        }
//        public string Author
//        {
//            get { return this.author; }
//            set { this.author = value; }
//        }

        /*        public override string ToString() 
                {
                    return String.Format("{0},{0},{0}", MyOrderDetail.ISBN, MyOrderDetail.Quantity, MyOrderDetail.Price);
                }
        */

    }
}
