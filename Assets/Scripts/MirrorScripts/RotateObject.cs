using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateObject : MonoBehaviour {

    public Material HighlightMaterial;

    public static GameObject SelectedMirror = null;
    private GameObject _outline;

    public float DegreesToRotateX = 0.0f;
    public float DegreesToRotateY = 45.0f;
    public float DegreesToRotateZ = 0.0f;
    public bool RotateOnX = false;
    public bool RotateOnY = true;
    public bool RotateOnZ = false;

    private float _currentSliderValue;
    private Vector3 _mouseReference;
    private bool _isSelected = false;
    private GameObject Player;
    private Slider ControlSlider;
    private Material DefaultMaterial;

    void Start()
    {
        DefaultMaterial = GetComponent<Renderer>().materials[0];
        Player = GameObject.Find("Player");
        ControlSlider = Player.GetComponent<PlayerController>().GetControlSlider();

        _isSelected = false;
        //_currentSliderValue = ControlSlider.value;
        //_outline = this.transform.Find("MirrorOutline").gameObject;

    }

    void Update()
    {
        if (_isSelected && _currentSliderValue != ControlSlider.value)
        {
            _currentSliderValue = ControlSlider.value;
        }

        // Add outline if selected
        /*if(SelectedMirror == this.gameObject) {
            // Debug.Log("Mirror " + this.GetHashCode() + " is still selected.");
            _outline.SetActive(true);
        } else {
            _outline.SetActive(false);
        }*/
    }

    void OnMouseUp()
    {
        SelectedMirror = this.gameObject;
        if (RotateOnX)
        {
            transform.Rotate(new Vector3(DegreesToRotateX, 0, 0));
        }
        if (RotateOnY)
        {
            transform.Rotate(new Vector3(0, DegreesToRotateY, 0));
        }
        if (RotateOnZ)
        {
            transform.Rotate(new Vector3(0, 0, DegreesToRotateZ));
        }
    }

    public void Deselect()
    {
        Material[] mats = GetComponent<Renderer>().materials;
        mats[0] = DefaultMaterial;
        GetComponent<Renderer>().materials = mats;
        _isSelected = false;
    }
}
