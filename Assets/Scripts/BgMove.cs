using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float moveRange;
    Vector3 oldPosition;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, transform.position.y, 0));

        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }
}
