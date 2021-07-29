using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PixelsDrawer : MonoBehaviour
{
    public Slider radius;
    public Slider strength;
    public Toggle colorSwitch;

    private void Update()
    {
        if (!Input.GetMouseButton(0)) return;

        var mousePosition = Input.mousePosition;
        var pixelsToChange = Physics2D.OverlapCircleAll(mousePosition, radius.value * 5)
            .Where(p => p.GetComponent<PixelHandler>() != null).Select(p => p.GetComponent<PixelHandler>());
        
        foreach (var pixel in pixelsToChange)
        {
            var pixelColor = pixel.GetColor();
            
            if (colorSwitch.isOn) pixel.ChangePixelColor(pixelColor - strength.value);
            else pixel.ChangePixelColor(pixelColor + strength.value);
        }
    }

    public void Reset()
    {
        foreach (var pixel in FindObjectsOfType<PixelHandler>()) pixel.ChangePixelColor(colorSwitch.isOn ? 1 : 0);
    }
}