using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    
    [SerializeField] private Slider r, g, b;
    [SerializeField] private Image colorPreview;
    [SerializeField] private UnityEvent OnChangeColor;
    
    private void Start()
    {
        ColorToSliders();
    }

    public void UpdateColor()
    {
        colorPreview.color = new Color(r.value, g.value, b.value, 1f);
        OnChangeColor.Invoke();
    }

    public void SetImageColor(Color color)
    {
        colorPreview.color = color;
        OnChangeColor.Invoke();
    }

    public Color GetColor()
    {
        return colorPreview.color;
    }

    private void ColorToSliders()
    {
        var color = colorPreview.color;
        r.value = color.r;
        g.value = color.g;
        b.value = color.b;
    }
}
