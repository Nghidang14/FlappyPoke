using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float oldPositionX;
    [SerializeField] float minRangeY = -1;
    [SerializeField] float maxRangeY = 1;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ResetWall")
        {
            obj.transform.position = new Vector3(oldPositionX, Random.Range(minRangeY, maxRangeY + 1), 0);
        }
    }
}
