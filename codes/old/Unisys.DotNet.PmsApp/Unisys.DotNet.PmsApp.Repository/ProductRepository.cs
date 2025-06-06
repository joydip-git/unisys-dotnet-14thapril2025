﻿using System.Collections.Generic;
using Unisys.DotNet.PmsApp.Models;

namespace Unisys.DotNet.PmsApp.Repository
{
    public class ProductRepository
    {
        public List<Product> Products { get; } = new List<Product> { 
                //named agument
                    new Product(price:100000M,id:1, description:"new laptop from dell",name:"Dell XPS",make:"Dell",year:"2019"),

                //object initializer
                    new Product(){ Id=2, Description="new laptop from HP",Make="HP", Name="HP Probook", Price=120000M, Year="2020"},

                    new Product{ Id=3, Description="new laptop from Lenovo",Make="Lenovo", Name="Lenovo Thinkpad", Price=110000M, Year="2018"}
        };
    }
}
