using OOPEksammenSW3.Products;

namespace OOPEksammenSW3.Commands
{
    public class CreditOffCommand : ICommand
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private int _productId;

        public CreditOffCommand(IStregsystem stregsystem, IStregsystemUI ui, int productId)
        {
            _stregsystem = stregsystem;
            _ui = ui;
            _productId = productId;
        }

        public void Execute()
        {
            IProduct product = _stregsystem.GetProductById(_productId);
            product.CanBeBoughtOnCredit = false; 
        }
    }
}