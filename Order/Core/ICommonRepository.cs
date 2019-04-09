﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Core
{
    public interface ICommonRepository<T> where T : IEntity
    {
        void Add(T topic);

        void Update(T topic);

       
    }
}
