using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveSceneId : MonoBehaviour
{
    public int sceneid;

    private Save sv = new Save();
    private string path;

    private void Start()
    {
        path = Path.Combine(Application.dataPath, "Save.json" );//����������
        if (File.Exists(path))//�������� ������ � �����
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            Debug.Log("Well" + sv.sceneid);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckData(int sceneid)//������ ������
    {
        sv.sceneid = sceneid;
        Debug.Log("Well" + sv.sceneid);
    }


    [Serializable]
    public class Save
    {
        public int sceneid;
    }
    private void OnApplicationQuit() //������ ������ ��� ������
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
}
