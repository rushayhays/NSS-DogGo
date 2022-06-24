using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class WalkerFormViewModel
    {
        public Walk Walk {get;set;}
        public List<Walker> Walkers { get; set; }
        public List<Dog> Dogs { get; set; }
    }
}
