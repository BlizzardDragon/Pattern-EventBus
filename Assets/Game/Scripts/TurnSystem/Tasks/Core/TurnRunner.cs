using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Roguelike_EventBus
{
    public class TurnRunner : MonoBehaviour
    {
        [SerializeField] private bool _runOnStart = true;
        [SerializeField] private bool _runOnFinish = true;

        private TurnPipeline<Task> _turnPipeline;


        [Inject]
        private void Construct(TurnPipeline<Task> turnPipeline)
        {
            _turnPipeline = turnPipeline;
        }

        private void OnEnable() => _turnPipeline.Finished += OnTurnPipelineFinished;
        private void OnDisable() => _turnPipeline.Finished -= OnTurnPipelineFinished;

        private void Start()
        {
            if (_runOnStart)
            {
                Run();
            }
        }

        [Button]
        public void Run()
        {
            _turnPipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            if (_runOnFinish)
            {
                Run();
            }
        }
    }
}