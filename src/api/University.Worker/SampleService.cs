using System.Threading.Tasks;

namespace University.Worker
{
    public class SampleService : IService
    {
        public async Task<bool> RunAsync()
        {
            // implement logic here
            // if nothing is done, return false to apply a slowness to the service frequency cycle
            var hasDoneSomething = false;
            return hasDoneSomething;
        }
    }
}
