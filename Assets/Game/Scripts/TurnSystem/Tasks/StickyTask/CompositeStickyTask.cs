using System.Collections.Generic;

namespace Roguelike_EventBus
{
    public sealed class CompositeStickyTask : StickyTask
    {
        public override bool Sticky { get; protected set; } = true;

        private readonly List<StickyTask> _tasks = new();
        private int _counter;

        public CompositeStickyTask(params StickyTask[] tasks)
        {
            foreach (var task in tasks)
            {
                Add(task);
            }
        }


        public void Add(StickyTask task)
        {
            if (!task.Sticky)
            {
                Sticky = false;
            }

            _tasks.Add(task);
        }

        protected override void OnRun()
        {
            _counter = 0;

            foreach (var task in _tasks)
            {
                task.Run(OnTaskFinished);
            }
        }

        private void OnTaskFinished(Task _)
        {
            _counter++;

            if (_counter >= _tasks.Count)
            {
                Finish();
            }
        }
    }
}