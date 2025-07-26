using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class player_move : MonoBehaviour
{

    [SerializeField]
    float rote = 0;
    Vector3 direction;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        move();
        Rote();
    }
    private void move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * 0.1f;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * 0.1f;
        }
    }
    private void Rote()
    {
        var ang = transform.localEulerAngles;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            ang.x += rote;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            ang.x -= rote;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            ang.y += rote;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            ang.y -= rote;
        }
        transform.localEulerAngles = ang;
    }
}
