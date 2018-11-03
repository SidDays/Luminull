﻿using System.Collections;
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

    [Tooltip("Specify the sequence number of this mirror, must start from 0")]
    public int MirrorNumber = -1;

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

        // Set a reference to the outline. Some Mirror objects don't have MirrorOutline as a direct child, so this hacky fix is required
        Transform outlineTransform = this.transform.Find("MirrorOutline");
        if (outlineTransform == null) {
            outlineTransform = this.transform.GetChild(0).transform.Find("MirrorOutline");
        }
        if (outlineTransform != null) {
            _outline = outlineTransform.gameObject;
        } else {
            Debug.LogWarning("Outline for Mirror " + this.GetHashCode() + " was not found!");
        }
    }

    void Update()
    {
        if (_isSelected && _currentSliderValue != ControlSlider.value)
        {
            _currentSliderValue = ControlSlider.value;
        }

        // Add outline if selected
        if(SelectedMirror == this.gameObject) {
            // Debug.Log("Mirror " + this.GetHashCode() + " is still selected.");
            _outline.SetActive(true);
        } else {
            _outline.SetActive(false);
        }
    }

    void OnMouseUp()
    {
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

    public void Rotate()
    {
        OnMouseUp();
    }

    public void Select() {
        _isSelected = true;
        SelectedMirror = this.gameObject;
    }

    public void Deselect()
    {
        // This code probably used to make the selected mirror orange
        // Material[] mats = GetComponent<Renderer>().materials;
        // mats[0] = DefaultMaterial;
        // GetComponent<Renderer>().materials = mats;

        _isSelected = false;
        SelectedMirror = null;
    }
}
