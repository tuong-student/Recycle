using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        GameObject gameObject = GameObject.Find(this.gameObject.name);
        if (gameObject != null && gameObject != this.gameObject) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
