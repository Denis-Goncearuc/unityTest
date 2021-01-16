using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DupeMovement : MonoBehaviour
{
    
    public GameObject nextCoin;
    public Vector3 followPos = Vector3.zero;
    public float playerSpeed = 6;

    private Vector3 eulerRotation;
    public float rotationDifference;
    private float timer;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        this.isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if(followPos != Vector3.zero)
        timer += Time.deltaTime;
        


        transform.position = Vector3.MoveTowards(transform.position, nextCoin.transform.position, playerSpeed * Time.deltaTime);
        
        if(!isActive)
            Destroy(this.gameObject);
        else if(timer > .03f)
        {
           eulerRotation = new Vector3(transform.localRotation.eulerAngles.x,
                                        Mathf.LerpAngle(transform.localRotation.eulerAngles.y, nextCoin.transform.localRotation.eulerAngles.y, 0.12f),
                                        transform.localRotation.eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);
            timer = 0;
        }
        
            
    

    }
    public void setNextCoin(GameObject nextCoin)
    {
        this.nextCoin = nextCoin;
    }


}
