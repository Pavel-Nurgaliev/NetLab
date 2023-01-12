using System;
using System.Threading;

namespace Timer
{
    public class Timer
    {
        private const int MillisecondsInSeconds = 1000;

        private const int TimeStop = 0;

        public event EventHandler<TimerEventArgs> CountDownStart;
        public event EventHandler<TimerEventArgs> RemainingTime;
        public event EventHandler<TimerEventArgs> CountDownStop;

        public Timer(string timerName = "Timer", int timerSeconds = 0)
        {
            TimerName = timerName;
            TimerSeconds = timerSeconds;
        }

        public string TimerName { get; set; }

        public int TimerSeconds { get; set; }

        public void StartTimer()
        {
            OnStart(new TimerEventArgs(TimerName, TimerSeconds));

            for (var i = 0; i < TimerSeconds; i++)
            {
                OnRemaining(new TimerEventArgs(TimerName, TimerSeconds - i));

                Thread.Sleep(MillisecondsInSeconds);
            }

            OnRemaining(new TimerEventArgs(TimerName, TimeStop));
            OnStop(new TimerEventArgs(TimerName, TimerSeconds));
        }

        private void OnStop(TimerEventArgs timerEventArgs)
        {
            CountDownStop?.Invoke(this, timerEventArgs);
        }

        private void OnStart(TimerEventArgs timerEventArgs)
        {
            CountDownStart?.Invoke(this, timerEventArgs);
        }

        private void OnRemaining(TimerEventArgs timerEventArgs)
        {
            RemainingTime?.Invoke(this, timerEventArgs);
        }
    }
}
