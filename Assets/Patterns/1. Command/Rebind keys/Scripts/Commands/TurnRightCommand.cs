using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class TurnRightCommand : Command
    {
        private MoveObject moveObject;
    

        public TurnRightCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }


        public override void Execute()
        {
            moveObject.TurnRight();
        }


        //Отмена — это просто противоположное действие
        public override void Undo()
        {
            moveObject.TurnLeft();
        }
    }
}
