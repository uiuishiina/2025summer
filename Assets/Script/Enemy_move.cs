using UnityEngine;
using System.Collections;
using static UnityEditor.PlayerSettings;

public class Enemy_move : MonoBehaviour
{
    Vector3 pos;
    float x, y, z,cpos,spos,time=0;
    bool c = false;
    public void set()
    {
        pos = transform.position;
        cpos = 0;
        spos = transform.position.y;
        x = Random.Range(0.1f, 3);//ïù
        y = Random.Range(1, 2);//ë¨ìx
        z = Random.Range(0.1f, 1);//à ëä
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (c) 
        {
            transform.position = new Vector3(pos.x, cpos + Mathf.PingPong(x * time * 2, x * 0.5f), pos.z);
        }
        else
        {
            transform.position = new Vector3(pos.x, spos + Mathf.PingPong(x * time / y- cpos, 2 * x), pos.z);
        }
    }

    public void Shake()
    {
        if (!c)
        {
            cpos = transform.position.y;
            c = true;
            StartCoroutine(Co());
        }
    }

    IEnumerator Co()
    {
        time = 0;
        GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        time = 0;
        cpos = cpos - spos;
        GetComponent<Renderer>().material.color = Color.white;
        c = false;
    }
}
