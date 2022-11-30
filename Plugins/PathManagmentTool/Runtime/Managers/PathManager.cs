using System;
using System.Linq;
using System.Runtime.CompilerServices;
using PathTool.Algorithms;
using PathTool.Controllers;
using PathTool.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PathTool.Managers
{
    /// <summary>
    /// Path Manager for keeping path controllers
    /// Note: It's important to make this class to parent of their path controllers in Unity inspector
    /// </summary>
    public class PathManager : PathModuleManager<PathController>
    {  
        #region EditorStruct
        [Serializable]
        public class PathEditorElement
        {
            [Header("Editor Elements"), Space]
            [Range(0, 20)] public float WireDiscRadius;
            [Range(0, 20)] public float PathThicknessScale;

            public Vector3 minimumSpawnPoint;
            public Vector3 maximumSpawnPoint;
            
            public bool ShowDistances;
        }
        #endregion

        [HideInInspector] public Vector3[] pointVectors; // Position array vector of our points.
        public PathEditorElement PathEditorElements;
        [SerializeField, Space] private AlgorithmEnum algorithm;

        public AlgorithmEnum AlgorithmEnum => algorithm;
        
        
#if UNITY_EDITOR
        private void OnDrawGizmos() => Paths = GetComponentsInChildren<PathController>().ToList();
#endif
        private void Start()
        { 
            Paths = GetComponentsInChildren<PathController>().ToList();
            FillPointVectors();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void FillPointVectors()
        {
            pointVectors = new Vector3[Paths.Count];
            
            for (var i = 0; i < Paths.Count; i++)
                pointVectors[i] = Paths[i].transform.position;
        }

        public void AssignObjectTransformToFirstIndex(Transform objectTransform)
        {
            objectTransform.transform.position = Paths[0].transform.position;
        }

        public void AssignObjectTransformToIndex(Transform objectTransform, int index)
        {
            if (index > Paths.Count)
            {
                Debug.LogError("Index cannot be greater than path's element count!");
                return;
            }

            objectTransform.transform.position = Paths[index].transform.position;
        }

        public void AssignObjectTransformToRandomIndex(Transform objectTransform)
        {
            var randomIndex = Random.Range(0, Paths.Count);
            objectTransform.transform.position = Paths[randomIndex].transform.position;
        }
    }
}