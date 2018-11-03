using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorManager : MonoBehaviour {

    private RotateObject[] Mirrors;
    private bool[] bIsMirrorAvailable;

    private int current;
    private RotateObject currentMirror;

	// Use this for initialization
	void Start () {
        GameObject[] mirrorsWithTag = GameObject.FindGameObjectsWithTag("Mirror");
        int size = 0;
        for(int i = 0; i < mirrorsWithTag.Length; i++)
        {
            RotateObject mirror = mirrorsWithTag[i].GetComponentInParent<RotateObject>();
            mirror.mirrorManager = this; 
            if(mirror.MirrorNumber > -1)
            {
                size++;
            }
            else
            {
                Debug.LogWarning("Mirror number did not assign\n");
            }
        }
        Mirrors = new RotateObject[size];
        bIsMirrorAvailable = new bool[size];
        for(int i = 0; i < size; i++)
        {
            bIsMirrorAvailable[i] = false;
        }

        for(int i = 0; i < mirrorsWithTag.Length; i++)
        {
            RotateObject mirror = mirrorsWithTag[i].GetComponentInParent<RotateObject>();
            if(mirror.MirrorNumber > -1)
            {
                int iMirrors = mirror.MirrorNumber;
                if(iMirrors >= Mirrors.Length)
                {
                    Debug.LogError("Mirror number out of bound, make sure the number is within 0 to total-1\n");
                    break;
                }
                Mirrors[iMirrors] = mirror;
                if(bIsMirrorAvailable[iMirrors])
                {
                    Debug.LogWarning("Mirror number duplicated\n");
                }
                bIsMirrorAvailable[iMirrors] = true;
            }
        }

        current = 0;
        currentMirror = Mirrors[current];
        currentMirror.Select();
	}
	
    public void RotateCurrentSelectedMirror()
    {
        currentMirror.Rotate();
    }

	public void SelectNextMirror()
    {
        currentMirror.Deselect();
        for(int i = current+1; i < Mirrors.Length; i++)
        {
            if (bIsMirrorAvailable[i])
            {
                current = i;
                currentMirror = Mirrors[current];
                currentMirror.Select();
                break;
            }
        }
    }

    public void SelectPreviousMirror()
    {
        currentMirror.Deselect();
        for (int i = current - 1; i >= 0; i--)
        {
            if (bIsMirrorAvailable[i])
            {
                current = i;
                currentMirror = Mirrors[current];
                currentMirror.Select();
                break;
            }
        }
    }

    public void SelectCertainMirror(int mirrorNumber)
    {
        currentMirror.Deselect();
        if (mirrorNumber >= 0 && mirrorNumber < Mirrors.Length && bIsMirrorAvailable[mirrorNumber])
        {
            current = mirrorNumber;
            currentMirror = Mirrors[current];
            currentMirror.Select();
        }
        else
        {
            Debug.LogWarning("The mirror " + mirrorNumber + " cannot be selected.");
        }
    }

    // TODO: handle current mirror is breaking
}
