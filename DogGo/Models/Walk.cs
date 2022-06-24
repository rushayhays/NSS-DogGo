using System;

namespace DogGo.Models
{
    public class Walk
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int WalkerId { get; set; }
        public int DogId { get; set; }

        //These are extra prooerties added in in order to make creating Views easier
        //It was dedided that this was a better option than crating an IWalk file and serveral slightly different Walk classes
        public Walker Walker { get; set; }
        public Dog Dog { get; set; }
        public string ClientName { get; set; }
    }
}
