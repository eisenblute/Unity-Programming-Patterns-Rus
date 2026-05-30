using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.MonsterSpawner
{
    //Этот код идентичен примеру паттерна «Прототип» из книги "Шаблоны игрового программирования",
    //Но я добавил метод разговора (Talk) и счётчик, чтобы мы могли видеть, что код работает
    public class SpawnController : MonoBehaviour
    {
        private Ghost ghostPrototype;
        private Demon demonPrototype;
        private Sorcerer sorcererPrototype;

        private Spawner[] monsterSpawners;


        void Start()
        {
            ghostPrototype = new Ghost(15, 3);
            demonPrototype = new Demon(11, 7);
            sorcererPrototype = new Sorcerer(4, 11);

            monsterSpawners = new Spawner[] {
                new Spawner(ghostPrototype),
                new Spawner(demonPrototype),
                new Spawner(sorcererPrototype)
            };

        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Если мы знаем, какой генератор используем, то можно легко привести к нужному типу монстра
                Spawner ghostSpawner = new Spawner(ghostPrototype);

                Ghost newGhost = ghostSpawner.SpawnMonster() as Ghost;

                newGhost.Talk();


                Spawner randomSpawner = monsterSpawners[Random.Range(0, monsterSpawners.Length)];

                _Monster randomMonster = randomSpawner.SpawnMonster();

                randomMonster.Talk();

                
                //Мы не можем использовать встроенный метод Instantiate от Unity, потому что эти объекты должны наследовать от Object
                //Ghost newGhost = Instantiate(ghostPrototype) as Ghost;
            }
        }
    }
}