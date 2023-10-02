using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Shar : MonoBehaviour
{
    Rigidbody rg;

    float a;
    float b;
    float c;

    void Start()
    {
        rg = GetComponent<Rigidbody>();

        var s = Random.Range(40, 200);

        push(s);
    }

    async void push(int s)
    {
        while (true)
        {
            a = Random.Range(-10, 10);
            b = Random.Range(-30, 30);
            c = Random.Range(-10, 10);

            Vector3 way = new Vector3(a, b, c);

            rg.AddForce(way, ForceMode.Impulse);

            await Task.Delay(s);
        }
    }
}
