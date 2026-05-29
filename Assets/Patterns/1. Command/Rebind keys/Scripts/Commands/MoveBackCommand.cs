using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class MoveBackCommand : Command
    {
        private MoveObject moveObject;


        public MoveBackCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }


        public override void Execute()
        {
            moveObject.MoveBack();
        }


        //Отмена — это просто противоположное действие
        public override void Undo()
        {
            moveObject.MoveForward();
        }
    }
}
