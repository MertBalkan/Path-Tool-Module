using System.Runtime.CompilerServices;
using PathTool.Managers;
using UnityEditor;
using UnityEngine;

namespace PathTool.Algorithms
{
    public class LinearAlgorithm : IAlgorithm
    {
        public AlgorithmEnum AlgorithmEnum { get; set; }
        private readonly PathManager _pathModuleManager;
        
        public LinearAlgorithm(PathManager pathModuleManager, AlgorithmEnum algorithmEnum)
        {
            _pathModuleManager = pathModuleManager;
            AlgorithmEnum = algorithmEnum;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ApplyAlgorithm()
        {
            AlgorithmEnum = AlgorithmEnum.Linear;
            
            if (_pathModuleManager.Paths == null) return;
            
            for (var index = 0; index < _pathModuleManager.Paths.Count - 1; index++)
            {
                var currentPath = _pathModuleManager.Paths[index];
                var nextPath = _pathModuleManager.Paths[index + 1];

                var currentPathPosition = currentPath.transform.position;
                var nextPathPosition = nextPath.transform.position;
                
                var calculatedDistance = (Vector3.Distance(currentPathPosition, nextPathPosition));
                
                Handles.color = Color.white;
                Handles.DrawLine(currentPathPosition, nextPathPosition, _pathModuleManager.PathEditorElements.PathThicknessScale);
                Handles.DrawLine(_pathModuleManager.Paths[^1].transform.position, _pathModuleManager.Paths[0].transform.position, _pathModuleManager.PathEditorElements.PathThicknessScale);
                
                ShowDistance(currentPathPosition, nextPathPosition, calculatedDistance);
            }        
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ShowDistance(Vector3 currentPathPosition, Vector3 nextPathPosition, float calculatedDistance)
        {
            var averagePositionBetweenPaths = (currentPathPosition + nextPathPosition) / 2;
            
            if(_pathModuleManager.PathEditorElements.ShowDistances) 
                Handles.Label(averagePositionBetweenPaths, ((int)calculatedDistance).ToString());
        }
    }
}