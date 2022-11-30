using System.Collections.Generic;
using UnityEngine;

namespace PathTool.Utils
{
    /// <summary>
    /// Abstract skeletal class for keeping paths
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PathModuleManager<T> : MonoBehaviour, IPathManager<T>
    {
        public List<T> Paths { get; set; }
    }
}