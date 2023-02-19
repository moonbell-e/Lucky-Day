using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolStorage : MonoBehaviour
{
    //static BoolsStorage bools;
    public bool hasIsolenta = false, hasFlashDrive = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        //bools = gameObject.AddComponent<BoolsStorage>();
    }
}