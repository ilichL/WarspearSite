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
    public class SkillService : ISkillService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        SkillService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateSkill(SkillCreateModel model)
        { 
            unitOfWork.Skills.AddAsync(mapper.Map<Skill>(model));
            await unitOfWork.CommitChanges();
        }

        public async Task<SkillModel> GetSkillBySkillNameAsync(String name)
        {   
            return mapper.Map<SkillModel>((
                await unitOfWork.Skills.FindBy(skill => skill.Name.Equals(name))).FirstOrDefaultAsync());
        }

        public async Task<SkillCreateModel> GetSkillByIdAsync(Guid id)
        {
            return mapper.Map<SkillCreateModel>(await unitOfWork.Skills.GetById(id));
        }

    }
}
