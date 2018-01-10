/*
 * Author:  Rick
 * Create:  2018/1/10 17:37:20
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SoundManager
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource m_ShootAudio;
    public AudioSource m_ExplodeAudio;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }


    public void PlayShoot()
    {
        m_ShootAudio.Play();
    }
    public void PlayExplode()
    {
        m_ExplodeAudio.Play();
    }
}
