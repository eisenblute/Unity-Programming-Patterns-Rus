using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    //Этот класс не разделяет данные между всеми объектами
    public class Heavy
    {
        private float health;

        private Data data;


        public Heavy()
        {
            health = Random.Range(10f, 100f);

            data = new Data();
        }
    }
}
