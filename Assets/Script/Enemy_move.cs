using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Enemy_move : MonoBehaviour
{
    Vector3 pos;
    float x, y, z;
    public void set()
    {
        pos = transform.position;
        x = Random.Range(0.1f, 3);
        y = Random.Range(0.1f, 2);
        z = Random.Range(0.1f, 1);
    }
    void FixedUpdate()
    {

        //transform.position = new Vector3(pos.x, pos.y + Mathf.PingPong(x * Time.time / y + z, 2 * x), pos.z);
    }
}
