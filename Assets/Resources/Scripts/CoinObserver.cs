using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoinObserver : MonoBehaviour
{
    public List<GameObject> coinQueue;
    [SerializeField]
    private GameObject head;
    public GameObject dupeCoin;
    public Vector3 spawnPosOffset;
    public Vector3 lastCoinPos;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        coinQueue = new List<GameObject>();
        coinQueue.Add(head);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("e"))
            addCoin();


    }

    public void addCoin()
    {
        lastCoinPos = coinQueue.Last().transform.position;
        GameObject temp = Instantiate(dupeCoin, lastCoinPos + spawnPosOffset, Quaternion.identity, this.gameObject.transform);
        temp.GetComponent<DupeMovement>().setNextCoin(coinQueue.Last());
        coinQueue.Add(temp);
        if(coinQueue.Count > 5)
            camera.GetComponent<cameraFollow>().distance += 3;
    }

    public void deleteCoin()
    {
        coinQueue.Last().GetComponent<DupeMovement>().isActive = false;
        coinQueue.Remove(coinQueue.Last());
    }
}
