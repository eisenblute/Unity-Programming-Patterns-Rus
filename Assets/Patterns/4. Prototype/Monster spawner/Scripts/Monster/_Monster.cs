using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.MonsterSpawner
{
    //Родительский класс монстра
    public abstract class _Monster
    {
        //Этот метод реализует паттерн проектирования «Прототип»
        public abstract _Monster Clone();

        public abstract void Talk();
    }
}
