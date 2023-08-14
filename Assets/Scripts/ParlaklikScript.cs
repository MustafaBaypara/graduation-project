using UnityEngine;
using UnityEngine.UI;

public class ParlaklikScript : MonoBehaviour
{
    public Slider brightnessSlider;
    public Light directionalLight;

    private void Start()
    {
        // Slider'ın değerini başlangıçta mevcut parlaklık değeriyle ayarlayın
        brightnessSlider.value = directionalLight.intensity;
        
        // Slider'ın değeri değiştiğinde parlaklık ayarlamasını yapacak metodu tetikleyin
        brightnessSlider.onValueChanged.AddListener(AdjustBrightness);
    }

    private void AdjustBrightness(float value)
    {
        // Slider değerine göre parlaklık ayarlaması yapın
        directionalLight.intensity = value;
    }
}
