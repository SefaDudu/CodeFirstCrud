using CodeFirst_Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst_Ef.ViewModels.Home
{
    public class HomePageVM
    {
        public List<Kisiler> Kisiler { get; set; }
        public List<Adresler> Adresler { get; set; }
    }
}