using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Player_Senser : MonoBehaviour
{
    List<GameObject> Enemy = new List<GameObject>(), traget = new List<GameObject>();
    [SerializeField]
    float LookRote = 0;
    void Start()
    {
        LookRote *= Mathf.Deg2Rad;
    }

    public void list(List<GameObject>enemy)
    {
        Enemy = enemy;
    }
    void FixedUpdate()
    {
        var forward = transform.forward;
        Debug.Log(forward);
        for (int i = 0; i < Enemy.Count; i++)
        {
            var len = (Enemy[i].transform.position - transform.position).normalized;
            var dot = Vector3.Dot(forward, len);
            if (dot > LookRote)
            {
                traget.Add(Enemy[i]);
                Enemy[i].GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                Enemy[i].GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
