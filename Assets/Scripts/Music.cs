using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject musicGameObjects = GameObject.FindGameObjectWithTag("music");
        /**
                if (musicGameObjects )
                {
                    Destroy(this.gameObject);
                }
                DontDestroyOnLoad(this.gameObject);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
