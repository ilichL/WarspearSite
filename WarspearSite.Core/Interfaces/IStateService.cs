using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspearSite.Models;

namespace WarspearSite.Core.Interfaces
{
    public interface IStateService
    {
        Task CreateStateAsyc(SkillCreateModel model);
        Task<StateCreateModel> CalculateBasicStatesAsync(StateCreateModel model);
        Task<int> CalculatingHelthAsync(Guid HeroId);
        Task<bool> ChangeStateAsync(StateModel model);
        Task<StateModel> CraeteBaseStatesAsync(HeroCreateModel heroModel);
        Task<bool> RemoveStatesByIdAsync(Guid id);
        Task<bool> SaveStatesAsync(StateCreateModel model);
    }
}
