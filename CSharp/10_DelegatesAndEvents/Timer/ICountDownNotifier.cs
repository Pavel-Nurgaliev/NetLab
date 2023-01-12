namespace Timer
{
    public interface ICountDownNotifier
    {
        public void Init();
        public void Run();
        public void Unsubscribe();
    }
}
