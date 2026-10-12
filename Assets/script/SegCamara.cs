using UnityEngine;

public class SegCamara : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 offset = new Vector3(0,0,-10);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;

    }
}
