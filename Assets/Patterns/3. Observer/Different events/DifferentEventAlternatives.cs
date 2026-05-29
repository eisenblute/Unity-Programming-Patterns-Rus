using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Observer.DifferentEvents
{
    //Сводка всех различных альтернатив событий
    public class DifferentEventAlternatives : MonoBehaviour
    {
        //-----------------------------
        // Встроенная обработка событий 
        //-----------------------------

        //Встроенный в C# EventHandler
        //Требует "using System;"
        public event EventHandler myCoolEvent;
        //С параметрами
        public event EventHandler<MyName> myCoolEventWithParameters;


        //Встроенный в C# Action
        //Если у нас больше параметров, можем использовать Action. 
        //По сравнению с EventHandler, параметры не обязаны наследовать от EventArgs
        public event Action<MyName, MyAge> myCoolEventAction;


        //Встроенный в Unity UnityEvent
        //Требует "using UnityEngine.Events;"
        [FormerlySerializedAs("CoolUnityEvent")] public UnityEvent coolUnityEvent = new UnityEvent();
        
        //Если у вас есть параметры, нужно создать новый класс события, наследующий от UnityEvent<параметр1, параметр2, ...>
        public MyCustomUnityEvent coolCustomUnityEvent = new MyCustomUnityEvent();
        
        //Существует также UnityAction
        //Вы можете добавить несколько методов в один UnityAction, и мы можем добавить несколько UnityAction в один UnityEvent
        //Затем UnityEvent вызовет все связанные с ним UnityAction, которые, в свою очередь, вызовут все методы, связанные с UnityAction
        //Это упростит удаление групп: если привязать группу к одному UnityAction, то можно просто удалить её
        //Создание UnityAction: UnityAction unityAction = new UnityAction(SomeMethodThatShouldBeCalled);
        //Добавление нового метода к тому же UnityAction: unityAction += SomeOtherMethodThatShouldBeCalled

        //Проблема с UnityEvents
        //Чтобы узнать, сколько подписчиков "слушает" событие: thisEvent.GetPersistentEventCount(); 
        //Но это число не всегда точное, потому что Unity по какой-то причине считает только постоянно сериализованные (например, добавленные в инспекторе), а не добавленные в коде. Если вам нужна эта функциональность, используйте C# события



        //-----------------------------
        // Пользовательская обработка событий
        //-----------------------------

        //Пользовательский делегат с теми же параметрами, что и встроенный EventHandler
        public delegate void MyEventHandler(object sender, EventArgs e);
        
        //Пользовательский делегат без параметров
        public MyEventHandler myEventHandler;
        
        public delegate void MyEventHandlerEmpty();

        //Событие, принадлежащее пользовательскому делегату
        public event MyEventHandlerEmpty myCoolCustomEvent;



        void Start()
        {
            myCoolEvent += DisplayStuff;

            myCoolEventWithParameters += DisplayStuffCustomArgs;

            myCoolEventAction += DisplayStuffCustomParameters;

            coolUnityEvent.AddListener(DisplayStuffEmpty);

            coolCustomUnityEvent.AddListener(DisplayStuffCustomParameters);

            myCoolCustomEvent += DisplayStuffEmpty;
            
            myEventHandler += DisplayStuff;
        }



        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Встроенные
                myCoolEvent?.Invoke(this, null);

                myCoolEventWithParameters?.Invoke(this, new MyName("InsertFunnyName"));

                myCoolEventAction?.Invoke(new MyName("InsertFunnyName"), new MyAge(5));

                coolUnityEvent?.Invoke();

                coolCustomUnityEvent?.Invoke(new MyName("InsertFunnyName"), new MyAge(5));

                //Пользовательские
                myEventHandler?.Invoke(this, null);

                myCoolCustomEvent?.Invoke();
            }
        }



        //Что вызовет событие
        private void DisplayStuff(object sender, EventArgs args)
        {
            Debug.Log("Привет, это DisplayStuff");
        }

        private void DisplayStuffCustomArgs(object sender, MyName args)
        {
            Debug.Log($"Привет, меня зовут {args.name}");
        }

        private void DisplayStuffCustomParameters(MyName myName, MyAge myAge)
        {
            Debug.Log($"Привет, меня зовут {myName.name} и мой возраст {myAge.age}");
        }

        private void DisplayStuffEmpty()
        {
            Debug.Log("Привет, это пустой метод");
        }
    }



    //Параметры в EventHandler должны наследовать от EventArgs
    public class MyName : EventArgs
    {
        public string name;

        public MyName(string name)
        {
            this.name = name;
        }
    }

    public class MyAge
    {
        public int age;

        public MyAge(int age)
        {
            this.age = age;
        }
    }



    //Чтобы параметры работали с UnityEvents
    public class MyCustomUnityEvent : UnityEvent<MyName, MyAge>
    {
        //Должен быть пустым
    }
}