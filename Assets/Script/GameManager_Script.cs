using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameManager_Script : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Enemy;
    List<GameObject> enemy = new List<GameObject>();
    void Start()
    {
        set();
    }
    private void set()
    {
        var forward = Player.transform.forward;
        for(int i = 0; i < 24; i++)
        {
            float posz = Random.Range(10, 15), posy = Random.Range(-2, 3), posx = Random.Range(-10, 11);
            GameObject ene = Instantiate(Enemy, new Vector3(posx, posy, posz), Quaternion.identity);
            ene.GetComponent<Enemy_move>().set();
            enemy.Add( ene );
        }
        Player.GetComponent<Player_Senser>().list(enemy);
    }
}
