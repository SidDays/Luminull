using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateObject : MonoBehaviour {

    public Material HighlightMaterial;

    public static GameObject SelectedMirror = null;
    private GameObject _outline;
    public GameObject outlineNext;

    /// Required to select mirror on tap, MirrorManager initializes this itself
    public MirrorManager mirrorManager;

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
        // set reference to the outline next
        outlineTransform = this.transform.Find("MirrorOutlineNext");
        if(outlineTransform == null)
        {
            outlineTransform = this.transform.GetChild(0).transform.Find("MirrorOutlineNext");
        }
        if(outlineTransform != null)
        {
            outlineNext = outlineTransform.gameObject;
        }
        else
            Debug.LogWarning("outlineNext not found! (wrong child place)");
    }

    void Update()
    {

        // Add outline if selected
        if(SelectedMirror == this.gameObject && _outline != null) {
            // Debug.Log("Mirror " + this.GetHashCode() + " is still selected.");
            _outline.SetActive(true);
        } else if(_outline !=null) {
            _outline.SetActive(false);
        }
    }

    void OnMouseUp()
    {
        mirrorManager.SelectCertainMirror(MirrorNumber);
        Debug.Log("Selected mirror");
        Select();
    }

    public void Rotate()
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

    /// <summary>Only updates the outline visibility. MirrorManager controls which mirror is actually selected</summary>
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

    public void SelectAsNext()
    {
        outlineNext.SetActive(true);
    }

    public void DeselectAsNext()
    {
        outlineNext.SetActive(false);
    }
}
