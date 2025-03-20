using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float destroyPos = -24f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < destroyPos)
        {
            Destroy(gameObject);
        }
    }
}
