using System;
using System.Collections.Generic;
using System.Net.Mail;
using OOPEksammenSW3.Model.Global;
using OOPEksammenSW3.Model.Users;
using OOPEksammenSW3.Parsers;

namespace OOPEksammenSW3.Parsers
{
    public class UserParser : IParser<IUser>
    {
        public IList<IUser> Parse(IEnumerable<string> lines, IIdProvider idProvider)
        {
            IList<IUser> users = new List<IUser>();

            foreach (string line in lines)
            {
                string[] subs = line.Split(',');

                string idString = subs[0];
                int id = Convert.ToInt32(idString);

                string firstNameString = subs[1];
                Name firstName = new Name(firstNameString);

                string lastNameString = subs[2];
                Name lastName = new Name(lastNameString);

                string usernameString = subs[3];
                Username username = new Username(usernameString);

                string balanceString = subs[4];
                int balanceInt = Convert.ToInt32(balanceString);
                DanskKrone balance = new DanskKrone(balanceInt);

                string emailString = subs[5];
                MailAddress email = new MailAddress(emailString);

                User user =
                    new User(id, idProvider, firstName, lastName, username, balance, email);
                users.Add(user);
            }

            return users;
        }
    }
}