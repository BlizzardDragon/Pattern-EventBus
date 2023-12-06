namespace Roguelike_EventBus
{
    public abstract class StickyTask : Task
    {
        public abstract bool Sticky { get; protected set; }

        public static StickyTask Combine(StickyTask first, StickyTask second)
        {
            if (first is null)
            {
                return second;
            }

            if (second is null)
            {
                return first;
            }

            if (first is CompositeStickyTask firstCompositeTask)
            {
                firstCompositeTask.Add(second);
                return first;
            }

            if (second is CompositeStickyTask secondCompositeTask)
            {
                secondCompositeTask.Add(first);
                return second;
            }

            return new CompositeStickyTask(first, second);
        }
    }
}