﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Interfaces
{
    public interface IActorService
    {
        void DeleteActor(Actor actor);
        EmployeeState IsFree(Actor  actor);
        EmployeeState IsFree(Actor actor, Duration duration);
        IEnumerable<Actor> GetAllFreeActor();
        IEnumerable<Actor> GetAllFreeActor(Duration duration);
    }
}
