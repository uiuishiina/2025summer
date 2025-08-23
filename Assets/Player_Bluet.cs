using UnityEngine;
using UnityEngine.Timeline;
public class Player_Bluet : MonoBehaviour
{
    bool a = false;
    GameObject Enemy = null;
    Vector3 vector = new Vector3();
    Matrix4x4 matrix4X4 = Matrix4x4.identity;
    [SerializeField]
    float Angle = 20;
    [SerializeField]
    float speed = 0.05f;
    public void TargetSet(GameObject enemy, Vector3 vec)
    {
        Enemy = enemy;
        Setr(vec);
        Angle *= Mathf.Deg2Rad;
        Angle = Mathf.Cos(Angle);
        a = true;
    }
    void Setr(Vector3 vec)
    {
        var forward = vec.normalized;
        var right = new Vector3(1, 0, 0);
        var Up = new Vector3(0, 1, 0);
        if (vec.y==1||vec.y==-1)
        {
            Up = Vector3.Cross(forward, right).normalized;
            right = Vector3.Cross(Up, forward).normalized;
        }
        else
        {
            right = Vector3.Cross(transform.up, forward).normalized;
            Up = Vector3.Cross(forward, right).normalized;
        }
        Matrix4x4 m = new Matrix4x4();
        m.SetColumn(0, new Vector4(right.x, right.y, right.z, 0));
        m.SetColumn(1, new Vector4(Up.x, Up.y, Up.z, 0));
        m.SetColumn(2, new Vector4(forward.x, forward.y, forward.z, 0));
        m.SetColumn(3, new Vector4(0, 0, 0, 1));
        transform.rotation = m.rotation;
    }
    private void Update()
    {
        if (!a) { return; }
        Move();
        Rote();
        Collision();
    }
    private void Move()
    {
        transform.position += transform.forward * speed;
    }
    void Rote()
    {
        var vec = (Enemy.transform.position - transform.position).normalized;
        var forward = transform.forward;
        var dot = Vector3.Dot(forward, vec);
        if (dot > 0.99f) { return; }
        if (dot < Angle) { dot = Angle; }
        var rad = Mathf.Acos(dot) * 0.1f;
        var closs = Vector3.Cross(forward, vec);
        transform.rotation*= Quaternion.AngleAxis(Mathf.Rad2Deg * rad, closs);
    }
    void Collision()
    {
        Bounds myBounds = GetComponent<Renderer>().bounds;
        Bounds enemyBounds = Enemy.GetComponent<Renderer>().bounds;

        if (myBounds.Intersects(enemyBounds))
        {
            Enemy.GetComponent<Enemy_move>().Shake();
            Destroy(gameObject);
        }
    }
}
