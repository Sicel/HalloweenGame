using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour
{
    public Text myText;
    public Color fromColor;
    public Color toColor;

    float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 2;

        myText.color = Color.Lerp(fromColor, toColor, Mathf.Sin(timer * 0.5f) + 0.5f);
    }
}
