﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
    public abstract class HeadLightFactory
    {
        public abstract HeadLight CreateHeadLight();
    }
}
