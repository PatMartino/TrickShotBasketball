namespace Interfaces
{
    public interface ICommand
    {
        public void Execute();
        public void Execute(ushort value);
    }
}
