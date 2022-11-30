using PathTool.Managers;
using PathTool.Utils;

namespace PathTool.Algorithms
{
    public interface IAlgorithm
    {
        void ApplyAlgorithm();
        AlgorithmEnum AlgorithmEnum { get; set; }
    }
}