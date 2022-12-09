using System;
using PathTool.Algorithms;
using PathTool.Managers;
using PathTool.Utils;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PathTool.Controllers
{
    /// <summary>
    /// Path Controller class controls the paths through path manager
    /// Applies linear paths 
    /// </summary>
    [ExecuteInEditMode]
    public class PathController : PathModuleController<PathManager>
    {
        private IAlgorithm _algorithm;
        private void OnEnable()
        {
            try
            {
                if (PathModuleManager.Paths == null) return;
                PathModuleManager.Paths.Add(this);
            }
            catch (Exception e)
            {
                Debug.Log("Paths Created!");
            }
        }
        private void OnDisable() => PathModuleManager.Paths.Remove(this);

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            PathModuleManager = GetComponentInParent<PathManager>();

            switch (PathModuleManager.AlgorithmEnum)
            {
                case AlgorithmEnum.Linear:
                    _algorithm = new LinearAlgorithm(PathModuleManager, PathModuleManager.AlgorithmEnum);
                    break;
                case  AlgorithmEnum.CatmullRom:
                    _algorithm = new CatmullRomAlgorithm(PathModuleManager, PathModuleManager.AlgorithmEnum);
                    break;
            }
            
            _algorithm.ApplyAlgorithm();
            
            Handles.color = Color.cyan;
            Handles.DrawSolidDisc(transform.position, Vector3.up, PathModuleManager.PathEditorElements.WireDiscRadius / 2);
            Handles.DrawWireDisc(transform.position, Vector3.up, PathModuleManager.PathEditorElements.WireDiscRadius);
        }
#endif
                
        protected virtual void ApplySamePositionsForLastAndFirstElements()
        {
            PathModuleManager.Paths[0].gameObject.transform.position =
                PathModuleManager.Paths[^1].transform.position;
        }
    }
}