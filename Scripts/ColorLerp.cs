using UnityEngine;

public class ColorLerp : MonoBehaviour
{


    public Color color1, color2;
    public bool randomColor;
    public float lerpSpeed;

    Color lerpedColor = Color.white;

    void Update()
    {
        lerpedColor = Color.Lerp(color1, color2, Mathf.PingPong(Time.time * lerpSpeed, 1));

        if(randomColor)
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", RandomColor());
        else
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", lerpedColor);    
    }


     Color RandomColor()
    {
        // A different random value is used for each color component (if
        // the same is used for R, G and B, a shade of grey is produced).
        return new Color(Random.value * lerpSpeed, Random.value * lerpSpeed, Random.value * lerpSpeed);
    }
}