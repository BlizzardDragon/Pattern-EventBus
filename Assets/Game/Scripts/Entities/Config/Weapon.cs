using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Roguelike_EventBus.Config
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Affects/Weapon")]
    public sealed class Weapon : ScriptableObject
    {
        [SerializeReference]
        public IEffect[] Effects;

        [Button]
        public void SaveChanges()
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            Debug.Log("Changes saved!");
#endif
        }
    }
}