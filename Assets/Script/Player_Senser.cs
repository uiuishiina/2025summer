using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Senser : MonoBehaviour
{
    List<GameObject> Enemy = new List<GameObject>(), target = new List<GameObject>();
    List<(float D, GameObject E)> viewenemy = new List<(float, GameObject)>();
    [SerializeField]
    float LookRote = 0;
    float Min = 0;
    void Start()
    {
        LookRote *= Mathf.Deg2Rad;
        LookRote = Mathf.Cos(LookRote);
    }
    public void list(List<GameObject>enemy)
    {
        Enemy = enemy;
        for(int i = 0;i < Enemy.Count; i++)
        {
            Enemy[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }
    void FixedUpdate()
    {
        Check();
    }
    void Check()
    {
        var forward = transform.forward;
        viewenemy.Clear();
        for (int i = 0; i < Enemy.Count; i++)
        {
            var len = (Enemy[i].transform.position - transform.position).normalized;
            var dot = Vector3.Dot(forward, len);
            if (dot > LookRote)
            {
                viewenemy.Add((dot, Enemy[i]));
            }
            else
            {
                Enemy[i].GetComponent<Renderer>().material.color = Color.white;
            }
        }
        target = viewenemy
                .OrderByDescending(a => a.D)
                .Take(8)
                .Select(b => b.E)
                .ToList();
        foreach (var Object in target)
        {
            Object.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
