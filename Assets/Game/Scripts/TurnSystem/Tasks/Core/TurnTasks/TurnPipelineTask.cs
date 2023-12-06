using UnityEngine;

namespace Roguelike_EventBus
{
    public abstract class TurnPipelineTask<TTask, TTurnPipeline> : Task
        where TTask : Task
        where TTurnPipeline : TurnPipeline<TTask>
    {
        protected readonly TTurnPipeline _tPipeline;

        public TurnPipelineTask(TTurnPipeline tPipeline)
        {
            _tPipeline = tPipeline;
        }


        protected override void OnRun()
        {
            Debug.Log($"{typeof(TTurnPipeline).Name} started!");

            _tPipeline.Finished += OnTurnPipelineFinished;
            _tPipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            Debug.Log($"{typeof(TTurnPipeline).Name} finished!");

            _tPipeline.Finished -= OnTurnPipelineFinished;
            OnTurnPipelineTaskFinished();
            Finish();
        }

        public virtual void OnTurnPipelineTaskFinished()
        {

        }
    }
}