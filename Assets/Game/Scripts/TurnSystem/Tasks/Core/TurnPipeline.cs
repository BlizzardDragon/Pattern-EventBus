using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike_EventBus
{
    public class TurnPipeline<T> where T : Task
    {
        private int _currentIndex = -1;

        [ShowInInspector, ReadOnly]
        protected readonly List<T> _tasks = new();

        public event Action Finished;


        public virtual void AddTask(T task) => _tasks.Add(task);
        public void RemoveTask(T task) => _tasks.Remove(task);
        public void InsertTask(T task) => _tasks.Insert(_currentIndex + 1, task);
        public void CancelTurn() => _currentIndex--;
        public void SkipTurn() => _currentIndex++;
        public void Clear() => _tasks.Clear();

        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _tasks.Count)
            {
                Finished?.Invoke();
                return;
            }

            var task = _tasks[_currentIndex];
            Debug.Log($"{task.GetType().Name}");
            task.Run(OnTaskFinished);
        }

        private void OnTaskFinished(Task task)
        {
            _currentIndex++;
            RunNextTask();
        }
    }
}