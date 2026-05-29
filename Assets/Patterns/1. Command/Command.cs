using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    //Базовый класс для команд
    //Этот класс всегда должен выглядеть так, чтобы быть более общим, поэтому никаких конструкторов, параметров и т.д.!!!
    public abstract class Command
    {
        public abstract void Execute();

        public abstract void Undo();
    }
}
