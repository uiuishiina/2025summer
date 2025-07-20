using UnityEngine;

public class player_move : MonoBehaviour
{
    Vector3 vec = new Vector3();
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        move();
    }
    private void move()
    {
        /*
        var pos = transform.position;
        var direction = new Vector3();
        var length = (direction - pos).normalized;
        length *= 0.2f;
        transform.position = length;
        */
    }
}
