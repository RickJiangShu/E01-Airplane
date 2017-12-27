using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour
{
    public float m_Speed;
    public int m_Hp;
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void EmitLaser(Vector3 pos)
    {
        GameObject laser = Factory.Generate("PlayerLaser");
        laser.transform.position = pos;
    }
}
