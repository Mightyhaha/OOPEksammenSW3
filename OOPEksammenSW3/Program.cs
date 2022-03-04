using System.Collections.Generic;
using System.IO;
using System.Linq;
using OOPEksammenSW3.Controller;
using OOPEksammenSW3.Model;
using OOPEksammenSW3.Model.Loggers;
using OOPEksammenSW3.Model.Products;
using OOPEksammenSW3.Model.Global;
using OOPEksammenSW3.Model.Users;
using OOPEksammenSW3.Parsers;
using OOPEksammenSW3.View;

namespace OOPEksammenSW3
{
    internal class Program
    {        private static void Main(string[] args)
        {
            IParser<IProduct> productParser = new ProductParser();
            IList<IProduct> products = 
                productParser.Parse(File.ReadLines(@"../../../products.csv").Skip(1), new IdProvider());

            IParser<IUser> userParser = new UserParser();
            IList<IUser> users = 
                userParser.Parse(File.ReadLines(@"../../../users.csv").Skip(1), new IdProvider());

            IStregsystem stregsystem = new Model.Stregsystem(products, users, new IdProvider(), new Logger());

            IStregsystemUI ui = new StregsystemCLI(stregsystem);
            StregsystemController sc = new StregsystemController(ui, stregsystem);

            ui.Start();
        }
    }
}
