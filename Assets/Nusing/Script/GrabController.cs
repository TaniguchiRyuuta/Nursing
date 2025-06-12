using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    private int overlappingFingers = 0;
    private GameObject currentGrabbableObject = null;
    private bool canGrab = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentGrabbableObject != null && overlappingFingers == 0)
        {
            ReleaseObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finger") && other.gameObject != gameObject)
        {
            overlappingFingers++;
            Debug.Log(gameObject.name + "��" + other.gameObject.name + "�ƐڐG(�d�Ȃ萔:" + overlappingFingers + ")"); ;
            UpdateGrabState();
        }
        else if(canGrab && other.CompareTag("Grabbable") && currentGrabbableObject == null)
        {
            GrabObject(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Finger"))
        {
            overlappingFingers--;
            Debug.Log(gameObject.name + "��" + other.gameObject.name + "�Ɨ��ꂽ(�d�Ȃ萔:" + overlappingFingers + ")"); ;
            UpdateGrabState();
        }
    }

    private void UpdateGrabState()
    {
        // �w��2�{�ȏ�ɂȂ�����Grab�\
        canGrab = overlappingFingers >= 1;
        Debug.Log(gameObject.name + "- Can Grab" + canGrab);
    }

    private void GrabObject(GameObject grabbable)
    {
        currentGrabbableObject = grabbable;
        currentGrabbableObject.transform.SetParent(transform);

        Rigidbody rb = currentGrabbableObject.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.isKinematic = true;
        }
        Debug.Log(gameObject.name + "- Grabbed:" + currentGrabbableObject.name);
    }

    private void ReleaseObject()
    {
        if(currentGrabbableObject != null)
        {
            currentGrabbableObject.transform.SetParent(null);
            Rigidbody rb = currentGrabbableObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.isKinematic = false;
            }
            currentGrabbableObject = null;
            canGrab = false;
            overlappingFingers = 0;
            Debug.Log(gameObject.name + "- Relesed object.");
        }
    }
}
