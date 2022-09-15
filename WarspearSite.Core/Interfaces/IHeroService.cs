using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspearSite.Models;

namespace WarspearSite.Core.Interfaces
{
    public interface IHeroService
    {
        Task<bool> CreateHeroAsync(HeroCreateModel model);
        Task<HeroCreateModel> GetHeroesByIdAsync(Guid id);
        Task<HeroModel> GetHeroByNameWithSkillsAndStatesASync(String name);
        Task<bool> RemoveHeroWithStatesAsync(HeroModel model);
    }
}
