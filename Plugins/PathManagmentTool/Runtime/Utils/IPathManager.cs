using System.Collections.Generic;

namespace PathTool.Utils
{
    public interface IPathManager<T> 
    {
        public List<T> Paths { get; set; }
    }
}