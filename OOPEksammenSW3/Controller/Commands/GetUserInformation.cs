using OOPEksammenSW3.Model;
using OOPEksammenSW3.Model.Users;
using OOPEksammenSW3.View;

namespace OOPEksammenSW3.Controller.Commands
{
    public class GetUserInformationCommand : ICommand
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private Username _username;

        public GetUserInformationCommand(IStregsystem stregsystem, IStregsystemUI ui, Username username)
        {
            _stregsystem = stregsystem;
            _ui = ui;
            _username = username;
        }

        public void Execute()
        {
            IUser user = _stregsystem.GetUserByUsername(_username);
            _ui.DisplayUserInfo(user);
        }
    }
}