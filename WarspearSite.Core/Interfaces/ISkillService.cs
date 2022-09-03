using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspearSite.Core.Interfaces.Data;
using WarspearSite.Models;
using WarspesrSite.Data.Entity;

namespace WarspearSite.Core.Interfaces
{
    public interface ISkillService
    {
        Task CreateSkill(SkillCreateModel model);
        Task<SkillModel> GetSkillBySkillNameAsync(String name);
        Task<SkillCreateModel> GetSkillByIdAsync(Guid id);
    }
}
