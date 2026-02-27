using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;

    private float bgWidth = 0f;
   
    void Start()
    {
        startPos = transform.position;
        BoxCollider b = GetComponent<BoxCollider>();
        bgWidth = b.size.x;
    }


    void Update()
    {
        float d = startPos.x - transform.position.x;
        if (d > bgWidth * 0.5)
        {
            transform.position = startPos;
        }
    }
}
