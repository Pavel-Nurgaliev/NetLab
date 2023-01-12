using System;

namespace Timer.TimerHandlers
{
    public class TimerHandlerByMethods : ICountDownNotifier
    {
        private const string MessageRemainingTask = "[{0}]Timer:{1}: {2} seconds remaining";

        private Timer _timer;

        private static StartTimeRunTask _start;
        private static Action<string> _stop;

        public TimerHandlerByMethods(Timer timer, StartTimeRunTask start, Action<string> stop)
        {
            _timer = timer;

            _start = start;
            _stop = stop;
        }

        public void Init()
        {
            _timer.CountDownStart += StartTask;
            _timer.CountDownStop += StopTask;
            _timer.RemainingTime += PrintMessageAboutRemainingTime;
        }

        public void Run()
        {
            _timer.StartTimer();
        }

        public void Unsubscribe()
        {
            _timer.CountDownStart -= StartTask;
            _timer.CountDownStop -= StopTask;
            _timer.RemainingTime -= PrintMessageAboutRemainingTime;
        }

        private void StartTask(object sender, TimerEventArgs eventArgs)
        {
            _start(eventArgs.TimerName, eventArgs.TimerSeconds);
        }

        private void StopTask(object sender, TimerEventArgs eventArgs)
        {
            _stop(eventArgs.TimerName);
        }

        private void PrintMessageAboutRemainingTime(object sender, TimerEventArgs eventArgs)
        {
            Console.WriteLine(MessageRemainingTask,
                DateTime.Now.Second, eventArgs.TimerName, eventArgs.TimerSeconds);
        }
    }
}
