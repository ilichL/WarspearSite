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

        public HeroService(ISkillService skillService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.skillService = skillService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateHero(HeroCreateModel model)
        {
            model.Id = Guid.NewGuid();
            await unitOfWork.Heroes.AddAsync(mapper.Map<Hero>(model));
            await unitOfWork.CommitChanges();

            var skills = model.Skills.ToList();
            foreach (var skill in skills)
            {
                skill.HeroId = model.Id;
                skill.Id = Guid.NewGuid();
            }
            await skillService.SaveSkillsAsync(skills);
        }

        public async Task<HeroCreateModel> GetHeroesByIdAsync(Guid id)
        {
            return mapper.Map<HeroCreateModel>(await unitOfWork.Heroes.GetById(id));
        }

        public async Task<HeroModel> GetHeroByNameWithSkillsAndStates(String name)
        {
            var heroId = (await unitOfWork.Heroes.FindBy(hero => 
                hero.Name.Equals(name))).FirstOrDefaultAsync().Result.Id;

            return mapper.Map<HeroModel>(await unitOfWork.Heroes.GetByIdWithIncludes(heroId,hero => hero.States,
                hero => hero.States));
        }

    }
}
