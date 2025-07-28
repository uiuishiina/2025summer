using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Senser : MonoBehaviour
{
    List<GameObject> Enemy = new List<GameObject>(), target = new List<GameObject>();
    List<(float D, GameObject E)> viewenemy = new List<(float, GameObject)>();
    [SerializeField]
    float LookRote = 0;
    [SerializeField]
    GameObject Bluet;
    bool z = false;
    Vector3[] shotpos =
    {
        new Vector3(0,1,0),new Vector3(-1,0,0),new Vector3(0,-1,0),new Vector3(1,0,0),
        new Vector3(1,1,0),new Vector3(-1,1,0),new Vector3(-1,-1,0),new Vector3(1,-1,0)
    };
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
    private void FixedUpdate()
    {
        Check();
    }
    public void Z(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                z = true;
                break;
            case InputActionPhase.Canceled:
                z = false;
                BluetShot();
                break;
        }
    }
    void Check()
    {
        if (!z) { return; }
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
        foreach (var e in Enemy)
        {
            if (!target.Contains(e))
            {
                e.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    void BluetShot()
    {
        for(int i= 0;i<target.Count;i++)
        {
            GameObject bu = Instantiate(Bluet, transform.position + shotpos[i], Quaternion.identity);
            bu.GetComponent<Player_Bluet>().TargetSet(target[i],shotpos[i]);
        }
    }
}
