using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingletonPattern
{
    public class GameController : MonoBehaviour
    {

        void Start()
        {
            TestCSharpSingleton();

            TestUnitySingleton();
        }


        void Update()
        {

        }



        private void TestCSharpSingleton()
        {
            //Не работает, потому что это синглтон с приватным конструктором
            //SingletonCSharp singletonCSharp = new SingletonCSharp();

            //Это работает
            SingletonCSharp instance = SingletonCSharp.Instance;

            instance.TestSingleton();

            SingletonCSharp instance2 = SingletonCSharp.Instance;

            instance2.TestSingleton();
        }



        private void TestUnitySingleton()
        {
            SingletonUnity instance = SingletonUnity.Instance;

            instance.TestSingleton();

            SingletonUnity instance2 = SingletonUnity.Instance;

            instance2.TestSingleton();
        }
    }
}