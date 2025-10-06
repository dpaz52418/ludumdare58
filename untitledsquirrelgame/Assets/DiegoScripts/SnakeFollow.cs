using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject targetGameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (targetGameObject != null)
        {
            Transform targetTransform = targetGameObject.GetComponent<Transform>();
            Debug.Log("target position: " + targetTransform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
