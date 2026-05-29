using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer.StaticEvents
{
    //Иллюстрация статических событий
    //Основная идея в том, что когда враг умирает, мы добавляем очки к счёту
    public class StaticEventsController : MonoBehaviour
    {
        public Enemy enemyPrefab;

        private int score;

        private int enemiesKilled = 0;


        void Awake()
        {
            //Подписываемся на событие, которое происходит каждый раз, когда враг умирает
            //При смерти врага может происходить несколько действий, поэтому лучше размещать событие в классе врага!
            //Поскольку это статическое событие, нам нужно подписаться только один раз, а не на каждый экземпляр врага
            Enemy.onAnyEnemyDie += AddToScore;
        }


        void Update()
        {
            //Создаём новых врагов, которые умрут через некоторое время
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject newEnemy = Instantiate(enemyPrefab.gameObject, Random.insideUnitSphere, Quaternion.identity) as GameObject;

                //Убиваем врага автоматически через 3 секунды, что вызовет событие
                Destroy(newEnemy, 3f);
            }
        }


        //Этот метод подписывается на событие
        void AddToScore(Enemy enemyScript)
        {
            score += enemyScript.enemyValue;

            enemiesKilled += 1;

            Debug.Log($"Вы убили {enemiesKilled} врагов, и счёт составляет: {score}");
        }
    }
}