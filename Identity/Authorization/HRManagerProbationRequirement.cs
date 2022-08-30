using Microsoft.AspNetCore.Authorization;
using System.Net;
using System;
using Identity.Constants;


namespace Identity.Authorization
{
    public class HRManagerProbationRequirement: IAuthorizationRequirement
    {
        public HRManagerProbationRequirement(int probationMonths)
        {
            ProbationMonths = probationMonths;
        }

        public int ProbationMonths { get; }
    }

    public class HRManagerProbationRequirementHandler : AuthorizationHandler<HRManagerProbationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirement requirement)
        {
            if(!context.User.HasClaim(x=>x.Type == "EmploymentDate"))
                return Task.CompletedTask;

            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate").Value);
            var dateDiff = DateTime.Today - empDate;
            if(dateDiff.Days > 30 * requirement.ProbationMonths)
            {
               context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
