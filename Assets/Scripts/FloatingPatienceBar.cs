using UnityEngine;
using UnityEngine.UI;

public class FloatingPatienceBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //[SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        //camera = Camera.main;
    }

    public void UpdatePatienceBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = target.position + offset;
    }
}
