using UnityEngine;
using UnityEngine.UI;

public class FloatingSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = target.position + offset;
    }

    public void UpdateSlider(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
