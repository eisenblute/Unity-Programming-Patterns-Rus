using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------
// Базовая реализация паттерна «Синглтон» (Одиночка) на C#
//------------------------------------

namespace SingletonPattern
{
    //Это самый простой паттерн Синглтон. 
    //Проблема в том, что он не потокобезопасен. 
    //Если вам нужен потокобезопасный Синглтон, смотрите тут: https://csharpindepth.com/articles/singleton
    public class SingletonCSharp
    {
        //Статическая переменная, которая хранит ссылку на единственный созданный экземпляр
        private static SingletonCSharp instance = null;



        //Для проверки того, что конструктор вызывается только один раз
        private float randomNumber;



        //Способ получения ссылки на единственный созданный экземпляр, при необходимости создающий его.
        public static SingletonCSharp Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonCSharp();
                }

                return instance;
            }
        }



        //Единственный конструктор, который является приватным и не принимает параметров (одиночкам не разрешается иметь параметры)
        //Это предотвращает создание экземпляров другими классами, а также наследование (что нарушает паттерн)
        //Но некоторые спорят, что от одиночек можно наследовать...
        private SingletonCSharp()
        {
            randomNumber = Random.Range(0f, 1f);
        }



        //Для проверки
        public void TestSingleton()
        {
            Debug.Log($"Привет, я Синглтон, моё случайное число: {randomNumber}");
        }
    }
}