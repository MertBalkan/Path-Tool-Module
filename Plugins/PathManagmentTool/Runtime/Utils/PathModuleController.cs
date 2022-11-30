using UnityEditor;
using UnityEngine;

namespace PathTool.Utils
{
    /// <summary>
    /// Abstracts class module for controlling the paths 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PathModuleController<T> : MonoBehaviour
    {
        private T _pathModuleManager;

        protected T PathModuleManager
        {
            get
            {
                if (_pathModuleManager == null)
                {
                    _pathModuleManager = GetComponentInParent<T>();   
                }
                return _pathModuleManager;
            }
            set => _pathModuleManager = value;
        }
        
        protected virtual void Awake()
        {
            _pathModuleManager = GetComponentInParent<T>();
        }
        
        protected void DrawingLineBetweenPaths(GameObject currentPath, GameObject nextPath, Color handleColor, float thickness = 1)
        {
            Handles.color = handleColor;
            Handles.DrawLine(currentPath.transform.position, nextPath.transform.position, thickness);
        }
    }
}