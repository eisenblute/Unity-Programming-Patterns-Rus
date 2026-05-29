using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    //Смысл этой команды — ничего не делать
    //Используется вместо установки команды в null, поэтому называется «Null Object» (пустой объект), что является ещё одним паттерном
    public class DoNothingCommand : Command
    {
        public override void Execute()
        {
            
        }

        public override void Undo()
        {
            
        }
    }
}