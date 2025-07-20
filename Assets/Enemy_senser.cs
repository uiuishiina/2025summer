using UnityEngine;

public class Enemy_senser : MonoBehaviour
{
    [SerializeField]
    Transform Player = null;
    [SerializeField]
    float senser;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        var pos = transform.position;
        var playerpos = Player.position;
        var forward = Player.transform.forward;
        var direction = (pos - playerpos).normalized;
        var dot = Vector3.Dot(direction, forward);
        senser = Mathf.Rad2Deg * senser;
        var angle = Mathf.Cos(senser);
        if(dot > angle)
        {
            Debug.Log("d");
            return;
        }
        
    }
}
