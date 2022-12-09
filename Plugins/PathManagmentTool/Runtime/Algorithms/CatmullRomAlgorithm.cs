using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using PathTool.Managers;
using UnityEditor;

namespace PathTool.Algorithms
{
	public class CatmullRomAlgorithm : IAlgorithm
	{
		private readonly PathManager _pathModuleManager;
		public AlgorithmEnum AlgorithmEnum { get; set; }

		public CatmullRomAlgorithm(PathManager pathModuleManager, AlgorithmEnum algorithmEnum)
		{
			_pathModuleManager = pathModuleManager;
			AlgorithmEnum = algorithmEnum;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ApplyAlgorithm()
		{
			AlgorithmEnum = AlgorithmEnum.CatmullRom;
			Handles.color = Color.white;

			if(_pathModuleManager.Paths == null) return;
			
			for (var i = 0; i < _pathModuleManager.Paths.Count; i++)
			{
				try
				{
					DisplayCatmullRomSpline(i);
				}
				catch (Exception e)
				{
					Debug.LogWarning("Be sure to delete all paths. " + e.Message);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DisplayCatmullRomSpline(int pos)
		{
			Vector3 p0 = _pathModuleManager.Paths[ClampPositions(pos - 1)].transform.position;
			Vector3 p1 = _pathModuleManager.Paths[pos].transform.position;
			Vector3 p2 = _pathModuleManager.Paths[ClampPositions(pos + 1)].transform.position;
			Vector3 p3 = _pathModuleManager.Paths[ClampPositions(pos + 2)].transform.position;

			Vector3 lastPos = p1;

			float resolution = 0.1f;

			int loops = Mathf.FloorToInt(1f / resolution);

			for (int i = 1; i <= loops; i++)
			{
				float t = i * resolution;

				Vector3 newPos = GetCatmullRomPosition(t, p0, p1, p2, p3);

				Handles.DrawLine(lastPos, newPos, _pathModuleManager.PathEditorElements.PathThicknessScale);
				lastPos = newPos;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int ClampPositions(int pos)
		{
			int pathCount = _pathModuleManager.Paths.Count;
			
			if (pos < 0)
				pos = pathCount - 1;

			if (pos > pathCount)
				pos = 1;
			else if (pos > pathCount - 1)
				pos = 0;

			return pos;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector3 GetCatmullRomPosition(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			Vector3 a = 2f * p1;
			Vector3 b = p2 - p0;
			Vector3 c = 2f * p0 - 5f * p1 + 4f * p2 - p3;
			Vector3 d = -p0 + 3f * p1 - 3f * p2 + p3;

			Vector3 pos = 0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t));
			return pos;
		}
	}
}