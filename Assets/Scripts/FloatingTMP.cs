using TMPro;
using UnityEngine;

public class FloatingTMP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tMesh;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    public void UpdateText(string displayText)
    {
        tMesh.text = displayText;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = target.position + offset;
    }
}
