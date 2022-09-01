using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspearSite.Core.Interfaces.Data;
using WarspearSite.Models;
using WarspesrSite.Data.Entity;

namespace WarspearSite.Domain.Services
{
    public class SkillService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public async Task CreateSkill(SkillModel model)
        { 
            unitOfWork.Skills.AddAsync(mapper.Map<Skill>(model));
            await unitOfWork.CommitChanges();
        }
    }
}
