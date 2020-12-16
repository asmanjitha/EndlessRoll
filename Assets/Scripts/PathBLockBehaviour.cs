using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBLockBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelfDestroy(){
        Destroy(gameObject);
    }
}
