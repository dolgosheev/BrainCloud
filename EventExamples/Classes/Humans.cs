﻿using Events.Interfaces;
using System;

namespace Events.Classes
{
    internal class Humans : IHuman
    {
        public static event EventHandler<IHuman> HumanCreated;
        public static event EventHandler<IHuman> HumanEditions;
        public string Fname { get;}
        public string Sname { get;}
        public int Age { get; private set; }
        public void PlusYearAge()
        {
            Age++;
            HumanEditions?.Invoke(this,this);
        }
        protected Humans(string fname, string sname, int age)
        {
            Fname = fname;
            Sname = sname;
            Age = age;
            HumanCreated?.Invoke(this, this);
        }

    }
}