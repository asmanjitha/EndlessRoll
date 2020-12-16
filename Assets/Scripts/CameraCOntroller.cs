using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCOntroller : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateRotation", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = ball.transform.position + new Vector3(0, 0.5f,-1.5f);
        // gameObject.transform.rotation = ball.transform.rotation;
        
    }

    void UpdateRotation(){
        gameObject.transform.rotation = ball.transform.rotation;
    }
}
