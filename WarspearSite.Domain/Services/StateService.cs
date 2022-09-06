﻿using AutoMapper;
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
    public class StateService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }   

        public async Task CreateStateAsyc(SkillCreateModel model)
        {
            model.Id = Guid.NewGuid();
            await unitOfWork.Skills.AddAsync(mapper.Map<Skill>(model));
            await unitOfWork.CommitChanges();        
        }

        public async Task<StateCreateModel> CalculateBasicStates(StateCreateModel model)
        {
            var hero = await unitOfWork.Heroes.GetById(model.HeroId);
            switch(hero.Fraction)
            {
                case "Chosen": 
                    {
                        model.Energy += 10; 
                        break; 
                    }

                case "Fistborn": 
                    { 
                        model.PhisicalDamage *= (int)0.04 + model.PhisicalDamage;
                        model.MagicalDamage *= (int)0.04 + model.PhisicalDamage;
                        break;
                    }//added to all damage

                case "Mountain Clans": 
                    { 
                        model.Health *= (int)0.04 + model.Health; 
                        break; 
                    }// added without armor

                case "Forsaken": 
                    { 
                        model.EnergyRegeneration += 3; 
                        break; 
                    }
                default: // exeption
                    break;
            }
            return model;
        }
    }
}
