using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace University.Controllers
{
    //Here is the showcase of HTTP Api Practices follow https://tfs.amaris.com/tfs/O2F-IT%20Projects/Mantu%20Knowledge%20Base/_wiki/wikis/Mantu-Knowledge-Base.wiki/532/HTTP-API-Practices
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet(Name = nameof(GetResources))]
        [ProducesResponseType(typeof(List<ResourceVm>), StatusCodes.Status200OK)]
        public IActionResult GetResources()
        {
            return new JsonResult(_resourceService.GetAll());
        }

        [HttpGet("{id}", Name = nameof(GetResourceById))]
        [ProducesResponseType(typeof(ResourceVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetResourceById([FromRoute] int id)
        {
            var resource = _resourceService.GetById(id);

            if (resource == null)
            {
                return NotFound();
            }

            return new JsonResult(resource);
        }

        [HttpPost(Name = nameof(CreateResource))]
        [ProducesResponseType(typeof(ResourceVm), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateResource(ResourceVm newResouce)
        {
            if (string.IsNullOrEmpty(newResouce.ResourceInfo))
            {
                return BadRequest();
            }
            var createdResource = _resourceService.Create(newResouce);

            return new CreatedResult("resource location", createdResource);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(ResourceVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateResource([FromRoute] int id, [FromBody] ResourceVm resource)
        {
            var resourceToUpdate = _resourceService.GetById(id);
            if (resourceToUpdate == null)
            {
                return NotFound();
            }

            var updatedResource = _resourceService.Update(id, resource);

            return new JsonResult(updatedResource) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpDelete("{id}", Name = nameof(DeleteResource))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteResource([FromRoute] int id)
        {
            var resourceToUpdate = _resourceService.GetById(id);
            if (resourceToUpdate == null)
            {
                return NotFound();
            }

            _resourceService.Delete(id);

            return NoContent();
        }
    }

    //These classes are defined here for examples purposes.

    public class ResourceVm
    {
        public int ResourceId { get; set; }
        public string ResourceInfo { get; set; }
    }

    public interface IResourceService
    {
        List<ResourceVm> GetAll();
        ResourceVm GetById(int id);
        ResourceVm Create(ResourceVm resource);
        ResourceVm Update(int id, ResourceVm resource);
        void Delete(int id);
    }

    public class ResourceService : IResourceService
    {
        private readonly List<ResourceVm> _resources;

        public ResourceService()
        {
            _resources = new List<ResourceVm>()
                    {
                       new ResourceVm
                       {
                           ResourceId = 1,
                           ResourceInfo = "ResourceA"
                       },
                       new ResourceVm
                       {
                           ResourceId = 2,
                           ResourceInfo = "ResourceB"
                       }
                    };
        }
        public ResourceVm Create(ResourceVm resource)
        {
            _resources.Add(resource);
            return resource;
        }

        public void Delete(int id)
        {
            var resourceToRemove = _resources.Find(x => x.ResourceId == id);
            if (resourceToRemove != null)
                _resources.Remove(resourceToRemove);
        }

        public List<ResourceVm> GetAll()
        {
            return _resources;
        }

        public ResourceVm GetById(int id)
        {
            return _resources.FirstOrDefault(x => x.ResourceId == id);
        }

        public ResourceVm Update(int id, ResourceVm resource)
        {
            var resourceToUpdate = _resources.Find(x => x.ResourceId == id);
            resourceToUpdate.ResourceInfo = resource.ResourceInfo;
            return resourceToUpdate;
        }
    }
}