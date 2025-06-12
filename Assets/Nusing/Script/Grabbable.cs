using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] private string TargetTag = "Grabbable";
    [SerializeField] private GameObject targetObject;
    private bool isGrabbing;

    // Start is called before the first frame update
    void Start()
    {
        isGrabbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbing)
        {
            targetObject.transform.parent = transform;
            targetObject.transform.localPosition = Vector3.zero;
            targetObject.transform.localRotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals(TargetTag))
        {
            targetObject = other.gameObject;
            isGrabbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals(TargetTag))
        {
            targetObject = null;
            isGrabbing = false;
        }
    }
}
