using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TheGreatesrApplication.Models;
using TheGreatesrApplication.Models.Requests;
using TheGreatesrApplication.Services;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace TheGreatesrApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AKindController : ControllerBase
    {
        private IAKindRepository _kindOfAnimalRepository;

        public AKindController(IAKindRepository kindOfAnimalRepository)
        {
            _kindOfAnimalRepository = kindOfAnimalRepository;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateKindOfAnimal")]
        public ActionResult<int> Create([FromBody] CreateAKindRequest createRequest)
        {
            int res = _kindOfAnimalRepository.Create(new AnimalKind
            {
                Kind = createRequest.Kind,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateKindOfAnimal")]
        public ActionResult<int> Update([FromBody] UpdateAKindRequest updateRequest)
        {
            int res = _kindOfAnimalRepository.Update(new AnimalKind
            {
                AnimalKindId = updateRequest.AnimalKindId,
                Kind = updateRequest.Kind,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteKindOfAnimal")]
        public ActionResult<int> Delete(int KindOfAnimalId)
        {
            int res = _kindOfAnimalRepository.Delete(KindOfAnimalId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllKindsOfAnimal")]
        public ActionResult<List<AnimalKind>> GetAll()
        {
            return Ok(_kindOfAnimalRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetKindOfAnimalById")]
        public ActionResult<AnimalKind> GetById(int KindOfAnimalId)
        {
            return Ok(_kindOfAnimalRepository.GetById(KindOfAnimalId));
        }
    }
}
