using System;
using Timer.TimerHandlers;

namespace Timer.UI
{
    internal class Program
    {
        private const string MessageTimerStart = "[{0}]Timer:{1}: has started for {2} seconds";
        private const string MessageTimerStop = "[{0}]Timer:{1}: has finished";

        private const int TimerSecondsForRead = 1;
        private const int TimerSecondsForProcess = 2;
        private const int TimerSecondsForCheck = 5;

        private const string TaskNameReading = "Reading task";
        private const string TaskNameProcessing = "Processing task";
        private const string TaskNameChecking = "Cheking task";

        public static void Main(string[] args)
        {
            var timerReader = new Timer(TaskNameReading, TimerSecondsForRead);

            var timerProcessor = new Timer(TaskNameProcessing, TimerSecondsForProcess);

            var timerChecker = new Timer(TaskNameChecking, TimerSecondsForCheck);

            ICountDownNotifier[] timersHandlers = new ICountDownNotifier[3]
            { new TimerHandlerByLambdas(timerReader, TaskStart, TaskStop),
            new TimerHandlerByDelegates(timerProcessor, TaskStart, TaskStop),
            new TimerHandlerByMethods(timerChecker, TaskStart, TaskStop)};


            StartTimersHandlers(timersHandlers);
        }

        private static void StartTimersHandlers(ICountDownNotifier[] timersHandlers)
        {
            foreach (var timerHandler in timersHandlers)
            {
                timerHandler.Init();
                timerHandler.Run();
                timerHandler.Unsubscribe();
            }
        }

        public static void TaskStart(string taskName, int seconds)
        {
            Console.WriteLine(MessageTimerStart, DateTime.Now.Second, taskName, seconds);
        }

        public static void TaskStop(string taskName)
        {
            Console.WriteLine(MessageTimerStop, DateTime.Now.Second, taskName);

            Console.WriteLine();
        }
    }
}
