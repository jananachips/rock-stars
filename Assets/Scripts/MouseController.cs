using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(MeshCollider))]

public class MouseController : MonoBehaviour
{
    float happiness;
    private Vector3 screenPoint;
    private Vector3 offset;
    Vector3 curPosition;
    Renderer renderer;
    public Slider slider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        
    }

    void OnMouseDown()
    {
        
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

        if (offset.magnitude > 0)
        {
            renderer.material.SetColor("_Color", Color.red);
            slider.value += 0.01f;
        }

    }

    private void OnMouseUp()
    {
        renderer.material.SetColor("_Color", Color.white);
    }

    private void Update()
    {
        // print(offset.magnitude);
        print(slider.value);
        
    }

}