using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateBackground : MonoBehaviour
{
    [SerializeField]Sprite[] animatedImages;
    [SerializeField] Image animateImage;
    int framesPerSecond = 10;

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * framesPerSecond) % animatedImages.Length;
        animateImage.sprite = animatedImages[index];
    }
}
