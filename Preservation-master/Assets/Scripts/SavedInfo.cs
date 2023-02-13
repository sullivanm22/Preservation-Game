using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInfo : MonoBehaviour
{
    public static string username { set; get; }
    public static int userRow { set; get; }
    [SerializeField] private GameObject info;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(info);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static SavedInfo()
    {

    }
}
