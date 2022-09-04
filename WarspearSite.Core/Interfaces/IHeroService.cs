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
        Task CreateHero(HeroCreateModel model);
        Task<HeroCreateModel> GetHeroesByIdAsync(Guid id);
        Task<HeroModel> GetHeroByNameWithSkillsAndStates(String name);
    }
}
