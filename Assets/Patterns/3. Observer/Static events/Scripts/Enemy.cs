using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer.StaticEvents
{
    public class Enemy : MonoBehaviour
    {
        //Поскольку это статическое событие, нам нужно подписаться на него только один раз
        public static event Action<Enemy> onAnyEnemyDie;
        //Ценность врага (сколько очков даёт)
        public int enemyValue { get; private set; }


        void Start()
        {

        }


        void Update()
        {

        }


        private void OnDisable()
        {
            enemyValue = UnityEngine.Random.Range(0, 5);

            //Debug.Log(enemyValue);

            //Вызываем событие, и каждому методу, который подписан на это событие, отправляем ссылку на этот объект
            onAnyEnemyDie.Invoke(this);

            //Это тоже работает, но менее чётко
            //onAnyEnemyDie(this);
        }
    }
}