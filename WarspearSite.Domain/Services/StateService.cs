using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspearSite.Core.Interfaces.Data;

namespace WarspearSite.Domain.Services
{
    public class StateService
    {
        private readonly IUnitOfWork unitOfWork;

        public StateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }   

        public async Task 
    }
}
