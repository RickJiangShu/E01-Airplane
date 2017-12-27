/*
 * Author:  Rick
 * Create:  2017/12/27 16:59:01
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Factory
/// </summary>
public class Factory
{
    public static GameObject Generate(string prefabName)
    {
        GameObject go;
        if (!ObjectPool.TryPull(prefabName, out go))
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + prefabName);
            go = GameObject.Instantiate(prefab);
            go.name = prefabName;
        }
        return go;
    }
}
