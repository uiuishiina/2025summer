using UnityEngine;
using System.Collections;
using static UnityEditor.PlayerSettings;

public class Enemy_move : MonoBehaviour
{
    Vector3 pos;
    float x, y, z,cpos,spos;
    bool c = false;
    public void set()
    {
        pos = transform.position;
        cpos = transform.position.y;
        x = Random.Range(0.1f, 3);
        y = Random.Range(1, 2);
        z = Random.Range(0.1f, 1);
    }
    void FixedUpdate()
    {
        pos.x = transform.position.x;
        pos.z = transform.position.z;
        if (c) 
        {
            transform.position = new Vector3(pos.x, cpos/2 + Mathf.PingPong(x* Time.time*2, x*0.5f), pos.z);
        }
        else
        {
            transform.position = new Vector3(pos.x, spos/2 + Mathf.PingPong(x * Time.time / y + z, 2 * x), pos.z);
        }
    }

    public void Shake()
    {
        cpos = transform.position.y;
        c= true;
        StartCoroutine(Co());
    }

    IEnumerator Co()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Renderer>().material.color = Color.white;
        spos = transform.position.y;
        c = false;
    }
}
