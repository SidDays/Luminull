using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateObject : MonoBehaviour {

    public Material HighlightMaterial;
    public float DegreesToRotateX = 0.0f;
    public float DegreesToRotateY = 45.0f;
    public float DegreesToRotateZ = 0.0f;
    public bool RotateOnX = false;
    public bool RotateOnY = true;
    public bool RotateOnZ = false;

    private static readonly float MirrorRotateSpeed = 50;//100;
    private float _sensitivity;
    private float _currentSliderValue;
    private float _originalYRotation;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;
    private bool _selectionValid;
    private bool _mouseDown = false;
    private bool _isSelected = false;
    private bool _wasRotatedOnce = false;
    private GameObject Player;
    private Slider ControlSlider;
    private Material DefaultMaterial;

    void Start()
    {
        DefaultMaterial = GetComponent<Renderer>().materials[0];
        Player = GameObject.Find("Player");
        ControlSlider = Player.GetComponent<PlayerControllerTemp>().GetControlSlider();

        _sensitivity = 0.4f;
        _rotation = Vector3.zero;
        _originalYRotation = transform.localEulerAngles.y;
        _selectionValid = false;
        _mouseDown = false;
        _isSelected = false;
        _currentSliderValue = ControlSlider.value;

    }

    void Update()
    {
        //if (_isRotating)
        //{
        // offset
        if (_isSelected && _currentSliderValue != ControlSlider.value)
        {
            _currentSliderValue = ControlSlider.value;

            _mouseOffset = (Input.mousePosition - _mouseReference);

            /*// apply rotation
            _rotation.y = -(ControlSlider.value - 0.5f)*10;//-(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
            // rotate
            float YRotation = -(ControlSlider.value - 0.5f)*90;
            transform.localEulerAngles = new Vector3(0,_originalYRotation + YRotation,0);*/
            //transform.Rotate(_rotation);

            // store mouse
            _mouseReference = Input.mousePosition;
            //}
        }
    }

    void OnMouseDown()
    {
        _mouseDown = true;
        // rotating flag
        _isRotating = true;

        // store mouse
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // apply rotation
        //_rotation.y = -(ControlSlider.value - 0.5f) * 10;//-(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
        // rotate
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

        /*if(_mouseDown && _selectionValid)
        {
            _isSelected = !_isSelected;
            if(_isSelected)
            {
                if(!_wasRotatedOnce)
                {
                    _wasRotatedOnce = true;
                    ControlSlider.value = 0.5f;
                }
                else
                {
                    Debug.Log(_currentSliderValue);
                    ControlSlider.value = _currentSliderValue;
                }
                Player.GetComponent<PlayerControllerTemp>().SelectObject(gameObject);
                Material[] mats = GetComponent<Renderer>().materials;
                mats[0] = HighlightMaterial;
                GetComponent<Renderer>().materials = mats;
            }
            else
            {
                Player.GetComponent<PlayerControllerTemp>().DeselectObject();
            }
        }
        // rotating flag
        _isRotating = false;
        _mouseDown = false;*/
    }

    private void OnMouseEnter()
    {
        _selectionValid = true;
    }

    private void OnMouseExit()
    {
        _selectionValid = false;
    }

    public void Deselect()
    {
        Material[] mats = GetComponent<Renderer>().materials;
        mats[0] = DefaultMaterial;
        GetComponent<Renderer>().materials = mats;
        _isSelected = false;
    }
}
