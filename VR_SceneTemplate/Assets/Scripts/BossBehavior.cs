using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    List<Transform> enemies = new List<Transform>();

    Rigidbody rg;
    Transform selfPosition;

    Vector3 enemyPosition;

    Vector3 delta;

    public GameObject enemyList;
    public Text textPanel;

    int enemyCount;

    void Start()
    {
        rg = GetComponent<Rigidbody>();

        selfPosition = GetComponent<Transform>();

        enemies = enemyList.GetComponentsInChildren<Transform>().ToList();

        enemyCount = enemies.Count() - 1;

        textPanel.text = "ХОБА";

        pushBoss(1000);
    }

    async void pushBoss(int s)
    {
        await Task.Delay(1000);
        
        while (true)
        {
            enemyPosition = GetTarget().position;

            delta = enemyPosition - selfPosition.position;

            var speed = delta.magnitude < 5 ? 3 : 1;

            rg.AddForce(delta * speed, ForceMode.Impulse);

            await Task.Delay(s);
        }
    }

    Transform GetTarget()
    {
        enemies = enemyList.GetComponentsInChildren<Transform>().ToList();

        var lowest = 1000.1;

        var targetPos = enemies[0];

        foreach (var currEnemy in enemies)
        {
            enemyPosition = currEnemy.position;

            delta = enemyPosition - selfPosition.position;

            if (delta.magnitude < lowest)
            {
                lowest = delta.magnitude;
                targetPos = currEnemy;
            }

            enemies = enemyList.GetComponentsInChildren<Transform>().ToList();
        }

        return targetPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            enemyCount--;

            textPanel.text = "осталось противников: " + enemyCount;
        }
    }
}

// way = new Vector3(delta.x, 0, delta.z);