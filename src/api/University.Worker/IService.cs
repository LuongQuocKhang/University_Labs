using System.Threading.Tasks;

namespace University.Worker
{
    public interface IService
    {
        Task<bool> RunAsync();
    }
}
