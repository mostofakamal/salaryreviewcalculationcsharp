using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_Review_Calculation.Calculator
{
    public enum Role
    {
        DEVELOPER,
        TEAMLEAD,
        PROJECTMANAGER,
        CTO,

    }

    public static class RoleExtensinos
    {
        public static Impact GetImpact(this Role role)
        {
            switch (role)
            {
                case Role.DEVELOPER:
                    return new Impact(0.2, 0.2, 0.2, 0.2, 0.2);
                case Role.TEAMLEAD:
                    return new Impact(0.3, 0.1, 0.3, 0.3, 0.0);
                case Role.PROJECTMANAGER:
                    return new Impact(0.2, 0.1, 0.3, 0.4, 0.1);
                case Role.CTO:
                    return new Impact(0.1, 0.3, 0.3, 0.3, 0.0);
                default:
                    return new Impact(0, 0.0, 0.0, 0.0, 0.0);
            }
        }
    }
}
