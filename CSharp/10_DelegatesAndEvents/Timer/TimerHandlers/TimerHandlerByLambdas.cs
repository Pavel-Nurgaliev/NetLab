using System;

namespace Timer.TimerHandlers
{
    public class TimerHandlerByLambdas : ICountDownNotifier
    {
        private const string MessageRemainingTask = "[{0}]Timer:{1}: {2} seconds remaining";

        private static Timer _timer;

        private static StartTimeRunTask _start;
        private static Action<string> _stop;

        private EventHandler<TimerEventArgs> _startTask = (sender, eventArgs) =>
        _start(eventArgs.TimerName, eventArgs.TimerSeconds);

        private EventHandler<TimerEventArgs> _remainingTask = (sender, eventArgs) =>
        PrintMessageAboutRemainingTime(eventArgs.TimerName, eventArgs.TimerSeconds);

        private EventHandler<TimerEventArgs> _stopTask = (sender, eventArgs) =>
        _stop(eventArgs.TimerName);

        public TimerHandlerByLambdas(Timer timer, StartTimeRunTask start, Action<string> stop)
        {
            _timer = timer;

            _start = start;
            _stop = stop;
        }

        public void Init()
        {
            _timer.CountDownStart += _startTask;
            _timer.CountDownStop += _stopTask;
            _timer.RemainingTime += _remainingTask;
        }

        public void Run()
        {
            _timer.StartTimer();
        }

        public void Unsubscribe()
        {
            _timer.CountDownStart -= _startTask;
            _timer.CountDownStop -= _stopTask;
            _timer.RemainingTime -= _remainingTask;
        }

        private static void PrintMessageAboutRemainingTime(string taskName, int seconds)
        {
            Console.WriteLine(MessageRemainingTask,
                DateTime.Now.Second, taskName, seconds);
        }
    }
}
