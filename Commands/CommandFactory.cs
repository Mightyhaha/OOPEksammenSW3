using System.Collections.Generic;
using System.Linq;
using OOPEksammenSW3.Global;
using OOPEksammenSW3.Users;
using System;

namespace OOPEksammenSW3.Commands
{
    public class CommandFactory
    {
        private IStregsystemUI _ui;
        private IStregsystem _stregsystem;

        public CommandFactory(IStregsystemUI ui, IStregsystem stregsystem)
        {
            _ui = ui;
            _stregsystem = stregsystem;
        }

        public ICommand Parse(string command)
        {
            IEnumerable<string> terms = command.Split(" ");
            string verb = terms.First();
            IList<string> nouns = terms.Skip(1).ToList();

            switch (verb)
            {
                case ":q" or ":quit":
                    return ParseQuit(nouns);
                case ":activate":
                    return ParseActivate(verb, nouns);
                case ":deactivate":
                    return ParseDeactivate(verb, nouns);
                case ":crediton":
                    return ParseCreditOn(verb, nouns);
                case ":creditoff":
                    return ParseCreditOff(nouns);
                case ":addcredit":
                    return ParseAddCredit(nouns);
                default:
                    return ParseUserRequest(verb, nouns);
            }
        }

        private ICommand ParseUserRequest(string verb, IList<string> nouns)
        {
            Username username = new Username(verb);
            IList<int> productIdList = nouns.Select(x => int.Parse(x)).ToList();

            if (nouns.Count <= 0)
                return new GetUserInformationCommand(_stregsystem, _ui, username);
            else
                return new BuyCommand(_stregsystem, _ui, username, productIdList);
        }

        private ICommand ParseAddCredit(IList<string> nouns)
        {
            if (nouns.Count() == 2)
            {
                Username username = new Username(nouns[0]);
                DanskKrone credit = new DanskKrone(int.Parse(nouns[1]));
                return new AddCreditCommand(_stregsystem, _ui, username, credit);
            }
            else
            {z
                throw new ArgumentException();
            }
        }

        private ICommand ParseCreditOff(IList<string> nouns)
        {
            if (nouns.Count() == 1)
            {
                int productId = int.Parse(nouns[0]);
                return new CreditOffCommand(_stregsystem, _ui, productId);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private ICommand ParseCreditOn(string verb, IList<string> nouns)
        {
            if (nouns.Count() == 1)
            {
                int productId = int.Parse(nouns[0]);
                return new CreditOnCommand(_stregsystem, _ui, productId);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private ICommand ParseDeactivate(string verb, IList<string> nouns)
        {
            if (nouns.Count() == 1)
            {
                int productId = int.Parse(nouns[0]);
                return new DeactivateCommand(_stregsystem, _ui, productId);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private ICommand ParseActivate(string verb, IList<string> nouns)
        {
            if (nouns.Count() == 1)
            {
                int productId = int.Parse(nouns[0]);
                return new ActivateCommand(_stregsystem, _ui, productId);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private ICommand ParseQuit(IList<string> nouns)
        {
            if (nouns.Count() == 0)
                return new QuitCommand(_ui);
            throw new ArgumentException();
        }
    }
}