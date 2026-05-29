using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    public class Flyweight
    {
        //Данные для каждого отдельного объекта
        private float health;

        //Это данные, которые являются общими для всех объектов, поэтому их нужно внедрить через конструктор
        private Data data;


        public Flyweight(Data data)
        {
            health = Random.Range(10f, 100f);

            this.data = data;
        }
    }
}