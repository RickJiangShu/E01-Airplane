/*
 * Author:  Rick
 * Create:  2017/12/26 15:57:21
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入口
/// </summary>
public class Main : MonoBehaviour
{
    public static readonly Rect screenArea = new Rect(0, 0, Screen.width, Screen.height);

    public float m_MeteorEmitInterval = 2.0f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("EmitMeteor", m_MeteorEmitInterval, m_MeteorEmitInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 陨石发射
    /// </summary>
    private void EmitMeteor()
    {
        int i = Random.Range(0, 2);
        string prefabName = "Meteor" + i;

        GameObject meteor;
        if (!ObjectPool.TryPull(prefabName, out meteor))
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + prefabName);
            meteor = GameObject.Instantiate(prefab);
            meteor.name = prefabName;
        }

        Vector3 screen = new Vector3(Random.Range(0f, Screen.width), Random.Range(Screen.height + 50f, Screen.height + 100), 10);
        meteor.transform.position = Camera.main.ScreenToWorldPoint(screen);
    }
}
