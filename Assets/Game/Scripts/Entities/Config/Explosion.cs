using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Roguelike_EventBus.Config
{
    [CreateAssetMenu(fileName = "New Explosion", menuName = "Affects/Explosion")]
    public sealed class Explosion : ScriptableObject
    {
        [SerializeReference]
        public IExplosionEffect[] ExplosionEffects;

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