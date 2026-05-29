using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    //Иллюстрирует паттерн «Приспособленец» (Flyweight)
    //Откройте профилировщик и нажмите на Memory, чтобы увидеть, сколько памяти используется
    //Переключайтесь между Heavy и Flyweight для сравнения, и вы должны увидеть разницу в несколько сотен мегабайт, хотя данные в данном случае — это всего 20 чисел double
    public class FlyweightController : MonoBehaviour
    {
        private List<Heavy> heavyObjects = new List<Heavy>();

        private List<Flyweight> flyweightObjects = new List<Flyweight>();


        void Start()
        {
            int numberOfObjects = 1000000;


            //Создаём «тяжёлые» объекты, которые не разделяют данные
            for (int i = 0; i < numberOfObjects; i++)
            {
                Heavy newHeavy = new Heavy();

                heavyObjects.Add(newHeavy);
            }


            //Создаём объекты-приспособленцы

            //Создаём данные, которые будут общими для всех объектов
            //Data data = new Data();

            //for (int i = 0; i < numberOfObjects; i++)
            //{
            //    Flyweight newFlyweight = new Flyweight(data);

            //    flyweightObjects.Add(newFlyweight);
            //}
        }
    }
}