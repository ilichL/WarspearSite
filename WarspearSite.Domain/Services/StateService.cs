using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using WarspearSite.Core.Interfaces.Data;
using WarspearSite.Models;
using WarspesrSite.Data.Entity;
using Newtonsoft.Json.Linq;
using WarspearSite.Core.Interfaces;

namespace WarspearSite.Domain.Services
{
    public class StateService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHeroService heroService;

        public StateService(IUnitOfWork unitOfWork, IMapper mapper, IHeroService heroService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.heroService = heroService;
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

        public async Task<int> CalculatingHelth(Guid HeroId)
        {//add defence
            var hero = await unitOfWork.Heroes.GetById(HeroId);
            string path = "";
            //string json = File.ReadAllText(path);
            List<HealthModel> models = JsonConvert.DeserializeObject<List<HealthModel>>("health.json");//json

            int modelHealth = 0;

            foreach(var model in models)
            {
                if(model.ClassName.Equals(hero.Class));
                    modelHealth = model.Health[hero.Level - 1];
            }

            return modelHealth;
        }

        public async Task<bool> ChangeState(StateModel model)
        {
            try
            {
                await unitOfWork.States.Update(mapper.Map<State>(model));
                await unitOfWork.CommitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task CraeteBaseStates(HeroCreateModel heroModel)
        {//Create base state of Hero.
            State state = new State()
            {
                Health = await CalculatingHelth(heroModel.Id),
                HealthRegeneration = 19,
                Energy = 100,
                EnergyRegeneration = 5,
                PhysicalDefense = 0,
                MagicalDefence = 0,
                PhisicalDamage = heroModel.Level,
                MagicalDamage = heroModel.Level,
                CritHit = 5,
                Accyarcy = 0,
                AttackSpeed = 0,
                Penetration = 0,
                SkillCooldown = 0,
                Stun = 0,
                Rage = 0,
                Ferocity = 0,
                AttackStrength = 0,
                DepthsFury = 0,
                PiercingAttack = 0,
                Dodge = 5,
                Resilience = 5,
                Parry = 0,
                Block = 0,
                StealHelth = 0,
                DamageReflection = 0,
                Solidity = 0.1m,
                Resistance = 0
    };
        }
        
    }
}
