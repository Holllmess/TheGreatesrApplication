using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TheGreatesrApplication.Models;
using TheGreatesrApplication.Models.Requests;
using TheGreatesrApplication.Services;

namespace TheGreatesrApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateSkill")]
        public ActionResult<int> Create([FromBody] CreateSkilRequest createRequest)
        {
            int res = _skillRepository.Create(new Skills
            {
                AnimalKindId = createRequest.AnimalKindId,
                CharacterSkill = createRequest.CharacterSkill,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateSkill")]
        public ActionResult<int> Update([FromBody] UpdateSkilRequest updateRequest)
        {
            int res = _skillRepository.Update(new Skills
            {
                SkillId = updateRequest.SkillId,
                //KindOfAnimalId = updateRequest.KindOfAnimalId,
                CharacterSkill = updateRequest.CharacterSkill,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteSkill")]
        public ActionResult<int> Delete(int skillId)
        {
            int res = _skillRepository.Delete(skillId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllSkills")]
        public ActionResult<List<Skills>> GetAll()
        {
            return Ok(_skillRepository.GetAll());
        }

        [HttpGet("get-all-by-animal-kind-id")]
        [SwaggerOperation(OperationId = "GetAllSkillsByAnimalKindId")]
        public ActionResult<List<Skills>> GetAllByAnimalKindId(int id)
        {
            return Ok(_skillRepository.GetAllByAnimalKindId(id));
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetSkillById")]
        public ActionResult<Skills> GetById(int skillId)
        {
            return Ok(_skillRepository.GetById(skillId));
        }
    }
}
