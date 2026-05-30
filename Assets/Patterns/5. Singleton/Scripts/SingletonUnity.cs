using UnityEngine;

//-----------------------------------
// Базовая реализация паттерна «Синглтон» (Одиночка) в Unity
//-----------------------------------

namespace SingletonPattern
{
    public class SingletonUnity : MonoBehaviour
    {
        //Статическая переменная, которая хранит ссылку на единственный созданный экземпляр
        private static SingletonUnity instance = null;
        
        //Для проверки того, что конструктор вызывается только один раз
        private float randomNumber;
        
        //Способ получения ссылки на единственный созданный экземпляр, при необходимости создающий его.
        public static SingletonUnity Instance
        {
            get
            {
                if (instance == null)
                {
                    //Ищем одиночку этого типа в сцене
                    var instance = GameObject.FindObjectOfType<SingletonUnity>();

                    //Если в сцене нет объекта-одиночки, мы должны добавить его
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("Unity Singleton");
                        instance = obj.AddComponent<SingletonUnity>();

                        //Инициализируем одиночку
                        instance.FakeConstructor();

                        //Объект-одиночка не должен уничтожаться при переключении между сценами
                        DontDestroyOnLoad(obj);
                    }
                }

                return instance;
            }
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;

                //Инициализируем одиночку
                instance.FakeConstructor();

                //Объект-одиночка не должен уничтожаться при переключении между сценами
                DontDestroyOnLoad(this.gameObject);
            }
            //Поскольку мы наследуем от MonoBehaviour, то можно случайно добавить несколько экземпляров в сцену,
            //что вызовет проблемы. Поэтому мы должны убедиться, что экземпляр у нас только один!
            else
            {
                Destroy(gameObject);
            }
        }


        //Поскольку этот скрипт наследуется от MonoBehaviour, мы не можем использовать конструктор, поэтому приходится изобретать свой
        private void FakeConstructor()
        {
            randomNumber = Random.Range(0f, 1f);
        }



        //Для проверки
        public void TestSingleton()
        {
            Debug.Log($"Привет, я Одиночка, моё случайное число: {randomNumber}");
        }
    }
}