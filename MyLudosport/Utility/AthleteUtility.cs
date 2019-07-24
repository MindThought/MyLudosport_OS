using Microsoft.AspNetCore.Http;
using MyLudosport.Data;
using MyLudosport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLudosport.Utility
{
    public class AthleteUtility
    {
        public Athlete CreateNewAthlete(string BattleName, HttpContext httpContext)
        {
            MyLudosportContext Context = httpContext.RequestServices.GetService(typeof(MyLudosport.Data.MyLudosportContext)) as MyLudosportContext;
            Athlete athlete = new Athlete { BattleName = BattleName, Form1 = StyleLevel.Student };
            return athlete;
        }

    }
}
