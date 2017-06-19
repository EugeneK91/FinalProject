using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructure.Enums
{
    public enum Role
    {
        [Description("Administrator")]
        Administrator = 1,
        [Description("Moderator")]
        Moderator,
        [Description("User")]
        User
    }
}