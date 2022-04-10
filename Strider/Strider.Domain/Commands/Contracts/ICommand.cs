namespace Strider.Domain.Commands.Contracts
{
    public interface ICommand
    {
        bool Validate();
    }
}
