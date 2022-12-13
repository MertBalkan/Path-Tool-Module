using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
using PathTool.Consts;
using PathTool.Controllers;
using PathTool.Managers;

[CustomEditor(typeof(PathManager))]
public class PathManagerInspectorEditor : Editor
{
    private GameObject _newPath;
    private PathManager _pathManager;

    private string _pathIndex;
    private string _pathCount;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _pathManager = (PathManager) target;

        EditorGUILayout.Space(10);
        EditorGUILayout.BeginVertical();
        
        _pathCount = EditorGUILayout.TextField(PathManagerEditorConst.TotalPathCount, _pathCount);
        CreateNewPaths(_pathManager);
        
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.Space(10);
        EditorGUILayout.BeginVertical();

        _pathIndex = EditorGUILayout.TextField(PathManagerEditorConst.TypPathIndex, _pathIndex);
        DeletePathIndexOf(_pathManager, _pathIndex);
        
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        
        DeleteAllPaths(_pathManager);
        
        EditorGUILayout.EndHorizontal();
    }

    public void CreateNewPaths(PathManager pathManager)
    {
        GUIStyle style = new GUIStyle()
        { 
            alignment = TextAnchor.MiddleCenter,
            normal = new GUIStyleState() { textColor = Color.green, background = Texture2D.grayTexture},
            active = new GUIStyleState() { textColor = Color.green, background = Texture2D.whiteTexture }
            
        };
    
        if (GUILayout.Button(PathManagerEditorConst.CreateNewPaths, style))
        {
            if(string.IsNullOrEmpty(_pathCount))
            {
                Debug.LogWarning(PathManagerEditorConst.EmptyIndexWarning);
                return;
            }

            var editorElements = _pathManager.PathEditorElements;
            
            for (int i = 0; i < Int32.Parse(_pathCount); i++)
            {
                _newPath = new GameObject("Path");
                _newPath.AddComponent<PathController>();

                _newPath.transform.position = 
                    new Vector3(
                        Random.Range(editorElements.minimumSpawnPoint.x, editorElements.maximumSpawnPoint.x),
                        Random.Range(editorElements.minimumSpawnPoint.y, editorElements.maximumSpawnPoint.y),
                        Random.Range(editorElements.minimumSpawnPoint.z, editorElements.maximumSpawnPoint.z)
                    );
                
                _newPath.transform.SetParent(pathManager.transform);
            }   
        }        
    }
    
    public void DeleteAllPaths(PathManager pathManager)
    {
        GUIStyle style = new GUIStyle()
        { 
            alignment = TextAnchor.MiddleCenter,
            normal = new GUIStyleState() { textColor = Color.red, background = Texture2D.grayTexture},
            active = new GUIStyleState() { textColor = Color.red, background = Texture2D.whiteTexture }
        };

        if (GUILayout.Button(PathManagerEditorConst.DeleteAllPaths, style))
        {
            for (int i = 0; i < pathManager.Paths.Count; i++)
            {
                if (Application.isEditor)
                    DestroyImmediate(pathManager.Paths[i].gameObject);
            }   
        }        
    }
    
    public void DeletePathIndexOf(PathManager pathManager, string index)
    {
        GUIStyle style = new GUIStyle()
        { 
            alignment = TextAnchor.MiddleCenter,
            normal = new GUIStyleState() { textColor = Color.red, background = Texture2D.grayTexture },
            active = new GUIStyleState() { textColor = Color.red, background = Texture2D.whiteTexture },
        };

        if (GUILayout.Button(PathManagerEditorConst.DeletePathIndexOf, style))
        {
            if(string.IsNullOrEmpty(index))
            {
                Debug.LogWarning(PathManagerEditorConst.EmptyIndexWarning);
                return;
            }

            try
            {
                var intIndex = Int32.Parse(index);
                
                if (intIndex > pathManager.Paths.Count)
                {
                    Debug.LogWarning(PathManagerEditorConst.GreaterThanWarning);
                    return;
                }
            
                if (Application.isEditor)
                    DestroyImmediate(pathManager.Paths[intIndex].gameObject);
            }
            catch (Exception e)
            {
                Debug.LogWarning(PathManagerEditorConst.TypeANumWarning);
            }
        }        
    }
}