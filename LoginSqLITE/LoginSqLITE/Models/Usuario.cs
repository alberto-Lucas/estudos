﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginSqLITE.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
