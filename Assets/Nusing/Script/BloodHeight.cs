using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodHeight : MonoBehaviour
{
    [SerializeField] private Material bloodMaterial;
    [SerializeField] private float targetHeight = 1f;
    [SerializeField] private float duration = 5f;

    private float currentHeight = 0f;
    private float elapsedTime = 0f;
    private bool isComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isComplete) return;

        elapsedTime += Time.deltaTime;

        float t = Mathf.Clamp01(elapsedTime / duration);
        float currentAlpha = Mathf.Lerp(0f, targetHeight, t);

        bloodMaterial.SetFloat("_BloodHeight" , currentHeight);

        if (t >= 1f)
        {
            isComplete = true;
        }
    }
}
