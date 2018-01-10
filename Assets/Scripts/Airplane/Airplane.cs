using UnityEngine;
using System;
using System.Collections;

public class Airplane : MonoBehaviour
{
    public float m_Speed;
    public int m_Hp;

    public event Action onHurted;
    public event Action onDead;

    protected int _hp;

    // Use this for initialization
    protected virtual void Start()
    {
        _hp = m_Hp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void EmitLaser(Vector3 pos)
    {
        GameObject laser = Factory.Generate("PlayerLaser");
        laser.transform.position = pos;

        SoundManager.instance.PlayShoot();
    }

    public virtual void Hurt()
    {
        _hp--;
        if (onHurted != null)
            onHurted();

        if (_hp <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        if (onDead != null)
            onDead();
    }
    
    public int hp
    {
        get { return _hp; }
    }
}
