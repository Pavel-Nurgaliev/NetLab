using System;

namespace Timer
{
    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(string name, int seconds)
        {
            TimerName = name;
            TimerSeconds = seconds;
        }
        public string TimerName { get; private set; }
        public int TimerSeconds { get; private set; }
    }
}
