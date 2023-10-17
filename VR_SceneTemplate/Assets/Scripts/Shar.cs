using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Shar : MonoBehaviour
{
    Rigidbody rg;
    Transform selfPosition;

    Vector3 bossPosition;

    Vector3 delta;

    Vector3 way;

    public GameObject Target;

    float a;
    float b;
    float c;

    void Start()
    {
        rg = GetComponent<Rigidbody>();

        selfPosition = GetComponent<Transform>();

        push(1000);
    }

    async void push(int s)
    {
        await Task.Delay(1000);

        while (true)
        {
            bossPosition = Target.transform.position;

            delta = bossPosition - selfPosition.position;

            a = Random.Range(-10, 10);
            b = Random.Range(-30, 30);
            c = Random.Range(-10, 10);

            Vector3 way = new Vector3(delta.x + a, delta.y + b, delta.z + c);

            var speed = delta.magnitude < 10 ? 3 : 2;

            rg.AddForce(way * speed, ForceMode.Impulse);

            await Task.Delay(s);
        }
    }
}
