using System.Linq;

namespace Roguelike_EventBus
{
    public class VisualPipeline : TurnPipeline<VisualTask>
    {
        public override void AddTask(VisualTask task)
        {
            var lastTask = _tasks.LastOrDefault();

            if (lastTask is null || !lastTask.Sticky && !task.Sticky)
            {
                _tasks.Add(task);
            }
            else
            {
                _tasks[^1] = VisualTask.Combine(lastTask, task);
            }
        }
    }
}