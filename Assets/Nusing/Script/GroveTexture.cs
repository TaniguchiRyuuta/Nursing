using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroveTexture : MonoBehaviour
{
    public Renderer leftHandRenderer;
    public Texture2D leftHandTexture;
    public Renderer rightHandRenderer;
    public Texture2D rightHandTexture;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LeftHand"))
        {
            if(leftHandRenderer != null && leftHandTexture != null)
            {
                leftHandRenderer.material.mainTexture = leftHandTexture;
                Debug.Log("テクスチャーを変更しました。");
            }
            else
            {
                Debug.LogWarning("LeftHandRendererまたはLeftHandTextureが設定されていません。");
            }
        }
        else if(other.CompareTag("RightHand"))
        {
            if(rightHandRenderer != null && rightHandTexture != null)
            {
                rightHandRenderer.material.mainTexture = rightHandTexture;
                Debug.Log("テクスチャーを変更しました。");
            }
            else
            {
                Debug.LogWarning("RightHandRendererまたはRightHandTextureが設定されていません。");
            }
        }
    }
}
