using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspearSite.Core.Interfaces;
using WarspearSite.Core.Interfaces.Data;
using WarspearSite.Models;
using WarspesrSite.Data.Entity;

namespace WarspearSite.Domain.Services
{
    public class HeroService : IHeroService
    {
        private readonly ISkillService skillService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IStateService stateService;

        public HeroService(ISkillService skillService, IUnitOfWork unitOfWork, IMapper mapper,
            IStateService stateService)
        {
            this.skillService = skillService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.stateService = stateService;
        }

        public async Task<bool> CreateHeroAsync(HeroCreateModel model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                await unitOfWork.Heroes.AddAsync(mapper.Map<Hero>(model));
                await unitOfWork.CommitChanges();
                model.States.HeroId = model.Id;
                model.States.Id = Guid.NewGuid();

                var skills = model.Skills.ToList();
                foreach (var skill in skills)
                {
                    skill.HeroId = model.Id;
                    skill.Id = Guid.NewGuid();
                }

                if (await skillService.SaveSkillsAsync(skills) && (await stateService.SaveStatesAsync(model.States)))
                    return true;

                return false;
            }

            catch
            {
                return false;
            }

        }

        public async Task<HeroCreateModel> GetHeroesByIdAsync(Guid id)
        {
            return mapper.Map<HeroCreateModel>(await unitOfWork.Heroes.GetById(id));
        }

        public async Task<HeroModel> GetHeroByNameWithSkillsAndStatesASync(String name)
        {
            var heroId = (await unitOfWork.Heroes.FindBy(hero => 
                hero.Name.Equals(name))).FirstOrDefaultAsync().Result.Id;

            return mapper.Map<HeroModel>(await unitOfWork.Heroes.GetByIdWithIncludes(heroId,hero => hero.States,
                hero => hero.States));
        }

        public async Task<bool> RemoveHeroWithStatesAsync(HeroModel model)
        {
            try
            {
                var hero = await (await unitOfWork.Heroes.FindBy(mod => mod.Name.Equals(model.Name),
                     mod => mod.Fraction.Equals(model.Fraction),
                     mod => mod.Server.Equals(model.Server))).FirstOrDefaultAsync();

                if(await stateService.RemoveStatesByIdAsync(hero.States.Id))
                {
                    await unitOfWork.Heroes.Remove(hero);
                    await unitOfWork.CommitChanges();
                    return true;
                }

                return false;

            }

            catch
            {
                return false;
            }

        }

    }
}
