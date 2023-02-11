using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TheGreatesrApplication.Models;
using TheGreatesrApplication.Models.Requests;
using TheGreatesrApplication.Services;

namespace TheGreatesrApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ASkillController : ControllerBase
    {
        private IASkillRepository _animalSkillRepository;

        public ASkillController(IASkillRepository animalSkillRepository)
        {
            _animalSkillRepository = animalSkillRepository;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateAnimalSkill")]
        public ActionResult<int> Create([FromBody] CreateASkilRequest createRequest)
        {
            int res = _animalSkillRepository.Create(new ASkills
            {
                AnimalId = createRequest.AnimalId,
                SkilId = createRequest.SkilId,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateAnimalSkill")]
        public ActionResult<int> Update([FromBody] UpdateASkilRequest updateRequest)
        {
            int res = _animalSkillRepository.Update(new ASkills
            {
                AnimalSkillId = updateRequest.AnimalSkillId,
                SkilId = updateRequest.SkilId,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteAnimalSkill")]
        public ActionResult<int> Delete(int animalSkillId)
        {
            int res = _animalSkillRepository.Delete(animalSkillId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllAnimalSkills")]
        public ActionResult<List<ASkills>> GetAll()
        {
            return Ok(_animalSkillRepository.GetAll());
        }

        [HttpGet("get-all-by-animal-id")]
        [SwaggerOperation(OperationId = "GetAllAnimalSkillsByAnimalId")]
        public ActionResult<List<ASkills>> GetAllByAnimalId(int id)
        {
            return Ok(_animalSkillRepository.GetAllByAnimalId(id));
        }

        [HttpGet("get-all-by-skill-id")]
        [SwaggerOperation(OperationId = "GetAllAnimalSkillsBySkillId")]
        public ActionResult<List<ASkills>> GetAllBySkillId(int id)
        {
            return Ok(_animalSkillRepository.GetAllBySkillId(id));
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetAnimalSkillById")]
        public ActionResult<ASkills> GetById(int animalSkillId)
        {
            return Ok(_animalSkillRepository.GetById(animalSkillId));
        }
    }
}
