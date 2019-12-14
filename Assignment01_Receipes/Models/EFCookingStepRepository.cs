using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Models
{
    public class EFCookingStepRepository
    {
        private ApplicationDbContext context;
        public EFCookingStepRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<CookingStep> CookingSteps => context.CookingSteps;

       
       
    }
}
