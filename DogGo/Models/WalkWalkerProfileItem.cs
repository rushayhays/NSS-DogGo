﻿using System;

namespace DogGo.Models
{
    public class WalkWalkerProfileItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int WalkerId { get; set; }
        public int DogId { get; set; }
        public string ClientName { get; set; }
    }
}
