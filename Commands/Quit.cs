namespace OOPEksammenSW3.Commands
{
    public class QuitCommand : ICommand
    {
        private IStregsystemUI _ui;

        public Quit(IStregsystemUI ui)
        {
            _ui = ui;
        }

        public void Execute()
        {
            _ui.Close();
        }
    }
}