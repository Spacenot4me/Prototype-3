using Unity.VisualScripting;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    
    private Vector3 startPos;
    private BoxCollider backgroundBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        backgroundBox = transform.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - (backgroundBox.size.x/2))
        {
            transform.position = startPos;
        }
    }
}
