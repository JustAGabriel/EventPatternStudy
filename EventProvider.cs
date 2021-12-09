using System;
using System.Timers;

namespace EventPatternStudy
{
    public class EventProvider
    {
        private readonly System.Timers.Timer _timer;
        private int _eventCounter = 1;
        public event EventHandler<NewNumberEventArgs> NewNumber;

        public EventProvider()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
            _timer.Interval = 3000;
            _timer.AutoReset = true;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            var eventArgs = new NewNumberEventArgs(_eventCounter++);
            NewNumber?.Invoke(this, eventArgs);
            if (eventArgs.Cancel)
            {
                Console.WriteLine($"Event '{nameof(NewNumber)}' was canceled.");
                Stop();
                
            }

            ;
        }

        public void Start() => _timer.Start();

        private void Stop() => _timer.Stop();
    }

    public class NewNumberEventArgs : EventArgs
    {
        public NewNumberEventArgs(int eventNumber)
        {
            EventNumber = eventNumber;
            TimeStamp = DateTime.Now;
        }

        public int EventNumber { get; }
        public DateTime TimeStamp { get; }
        public bool Cancel { get; set; }
    }
}