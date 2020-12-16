using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    [SerializeField] private GameObject pathBlock;
    private static Vector3 previousPosition = new Vector3(0,0,0);
    private static Vector3 prviousRotation = new Vector3();
    private static int curve = 1;
    [SerializeField] private Transform path;
    [SerializeField] private Material mat1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeneratePathblock();
    }

    public void GeneratePathblock(){

        int direction = Random.Range(0,2);
        int activateCoin = Random.Range(0,1000);

        GameObject block =  Instantiate(pathBlock);
        block.transform.parent = path;
        block.transform.position = previousPosition;
        block.GetComponent<Renderer>().material = mat1;

        if(direction == 0){
            curve += 1;
            Vector3 rotation = prviousRotation + new Vector3(0.0f, 1.25f, 0.0f);

            block.transform.rotation = Quaternion.Euler(rotation);
            prviousRotation = rotation;
        }else{
            curve -= 1;
            Vector3 rotation = prviousRotation + new Vector3(0.0f, -1.25f, 0.0f);

            block.transform.rotation = Quaternion.Euler(rotation);
            prviousRotation = rotation;
        }

        if(activateCoin == 0){
            block.transform.GetChild(0).gameObject.SetActive(true);
        }

        block.transform.Translate(Vector3.forward * 0.025f);
        previousPosition = block.transform.position;  
    }


    public void Stop(){
        gameObject.SetActive(false);
    }
}
