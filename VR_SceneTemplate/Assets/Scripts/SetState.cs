using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetState : MonoBehaviour
{
    public GameObject obj;

    public void SetStateBlock()
    {
        obj.SetActive(!obj.activeInHierarchy);
    }
}
