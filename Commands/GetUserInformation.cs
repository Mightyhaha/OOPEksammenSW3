using OOPEksammenSW3.Users;

namespace OOPEksammenSW3.Commands
{
    public class GetUserInformation : ICommand
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private Username _username;

        public GetUserInformation(IStregsystem stregsystem, IStregsystemUI ui, Username username)
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