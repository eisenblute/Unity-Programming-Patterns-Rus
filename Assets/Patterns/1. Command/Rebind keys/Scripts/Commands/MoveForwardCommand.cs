using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class MoveForwardCommand : Command
    {
        private MoveObject moveObject;


        public MoveForwardCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }


        public override void Execute()
        {
            moveObject.MoveForward();
        }


        //Отмена — это просто противоположное действие
        public override void Undo()
        {
            moveObject.MoveBack();
        }
    }
}
