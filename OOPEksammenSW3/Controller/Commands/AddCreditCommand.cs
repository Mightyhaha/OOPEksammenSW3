using OOPEksammenSW3.Model;
using OOPEksammenSW3.Model.Global;
using OOPEksammenSW3.Model.Users;
using OOPEksammenSW3.View;

namespace OOPEksammenSW3.Controller.Commands
{
    public class AddCreditCommand : ICommand
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private Username _username;
        private DanskKrone _credit;

        public AddCreditCommand(IStregsystem stregsystem, IStregsystemUI ui, Username username, DanskKrone credit)
        {
            _stregsystem = stregsystem;
            _ui = ui;
            _username = username;
            _credit = credit;
        }

        public void Execute()
        {
            IUser user = _stregsystem.GetUserByUsername(_username);
            _stregsystem.AddCreditToAccount(user, _credit);
        }
    }
}