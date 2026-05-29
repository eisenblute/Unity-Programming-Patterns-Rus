using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    //Этот класс обрабатывает все методы, которые перемещают объект, к которому он прикреплён
    public class MoveObject : MonoBehaviour
    {
        //Скорость перемещения объекта
        private const float MOVE_STEP_DISTANCE = 1f;


        //Эти методы будут выполняться своей собственной командой
        public void MoveForward()
        {
            Move(Vector3.forward);
        }

        public void MoveBack()
        {
            Move(Vector3.back);
        }

        public void TurnLeft()
        {
            Move(Vector3.left);
        }

        public void TurnRight()
        {
            Move(Vector3.right);
        }


        //Вспомогательный метод для большей обобщённости
        private void Move(Vector3 dir)
        {
            transform.Translate(dir * MOVE_STEP_DISTANCE);
        }
    }
}