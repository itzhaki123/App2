﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProject.Models
{
    public class GameUser
    {
        public int UserId { get; set; } = 1;
        public string UserName { get; set; } = "anonymous";
        public string Usermail { get; set; } = "None Email";
        public int Score { get; set; } = 0;
        public string UsingProduct { get; set; }
        public GameLevel CurrentLevel { get; set; } = new GameLevel();
    }
}
