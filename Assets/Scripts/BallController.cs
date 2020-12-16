using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text text;
    private int score = 0;
    private static float speed =  0.02f; 
    float previousheight = 0.086f;
    public PathGenerator pathGenerator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CaptureDeviceMotion();
    }

    void LateUpdate(){
        var currentheight = transform.position.y;
        
        var travel = currentheight - previousheight;
        if(travel > 10 || travel < -10){
            text.text = "Game Over Your score is " + score;
            gameObject.SetActive(false);
        }
        // previousheight = currentheight;
    }

    void CaptureDeviceMotion(){
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        dir.z = Input.acceleration.z;

        if (dir.sqrMagnitude > 1){
            dir.Normalize();
        }
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, dir.x*100, 0.0f));
        gameObject.transform.Translate(Vector3.forward *speed);

    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Coin"){
            score += 1;
        }
        text.text = score.ToString();

    }


    public void SpeeUp(){
        speed = 0.03f;
    }

    public void SpeedDown(){
        speed = 0.02f;
    }
}
