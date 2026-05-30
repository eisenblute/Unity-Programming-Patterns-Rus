using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.MonsterSpawner
{
    public class Demon : _Monster
    {
        private int health;
        private int speed;

        private static int demonCounter = 0;

        public Demon(int health, int speed)
        {
            this.health = health;
            this.speed = speed;

            demonCounter += 1;
        }

        public override _Monster Clone()
        {
            return new Demon(health, speed);
        }

        public override void Talk()
        {
            Debug.Log($"Привет, я демон номер {demonCounter}. Моё здоровье — {health}, а моя скорость — {speed}");
        }
    }
}
