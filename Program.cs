﻿using System;
using System.Globalization;

namespace OOPEksammenSW3
{
    internal class Program
    {        private static void Main(string[] args)
        {
            IStregsystem stregsystem = new Stregsystem(
                @"../../../products.csv", 
                @"../../../users.csv");
            IStregsystemUI ui = new StregsystemCLI(stregsystem);
            StregsystemController sc = new StregsystemController(ui, stregsystem);

            ui.Start();
        }
    }
}
