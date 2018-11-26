using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorManager : MonoBehaviour {

    private RotateObject[] Mirrors;
    private bool[] bIsMirrorAvailable;

    private int current;
    private RotateObject currentMirror;
    private RotateObject nextMirror;
    private RotateObject previousMirror;

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
                    Debug.LogWarning("Mirror number duplicated " + iMirrors + "\n");
                }
                bIsMirrorAvailable[iMirrors] = true;
            }
        }

        current = 0;
        currentMirror = Mirrors[current];
        currentMirror.Select();

        int NextIndex = GetNextMirror();
        if (NextIndex > -1)
        {
            nextMirror = Mirrors[NextIndex];
            nextMirror.SelectAsNext();
        }

        previousMirror = Mirrors[Mirrors.Length - 1];
        if (previousMirror != null)
        {
            previousMirror.SelectAsPrevious();
        }
	}
	
    public void RotateCurrentSelectedMirror()
    {
        currentMirror.Rotate();
    }

	public void SelectNextMirror()
    {
        int index = GetNextMirror();

        if (index > -1)
        {
            previousMirror.DeselectAsPrevious();
            previousMirror = currentMirror;
            previousMirror.SelectAsPrevious();
        }

        if (index > -1)
        {
            currentMirror.Deselect();
            current = index;
            currentMirror = Mirrors[current];
            currentMirror.Select();
        }

        index = GetNextMirror();
        if(index > -1)
        {
            nextMirror.DeselectAsNext();
            nextMirror = Mirrors[index];
            nextMirror.SelectAsNext();
        }
    }

    public void SelectPreviousMirror()
    {
        int index = GetPrevMirror();

        if (index > -1)
        {
            currentMirror.Deselect();
            current = index;
            currentMirror = Mirrors[current];
            currentMirror.Select();
        }

        int prevIndex = GetPrevMirror();
        if (prevIndex > -1)
        {
            previousMirror.DeselectAsPrevious();
            previousMirror = Mirrors[prevIndex];
            previousMirror.SelectAsPrevious();
        }

        index = GetNextMirror();
        if (index > -1)
        {
            nextMirror.DeselectAsNext();
            nextMirror = Mirrors[index];
            nextMirror.SelectAsNext();
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

    private int GetNextMirror()
    {
        for (int i = current + 1; i < Mirrors.Length; i++)
        {
            if (bIsMirrorAvailable[i])
            {
                return i;
            }
        }

        if(current + 1 >= Mirrors.Length)
        {
            return 0;
        }

        return -1;
    }

    private int GetPrevMirror()
    {
        for (int i = current - 1; i >= 0; i--)
        {
            if (bIsMirrorAvailable[i])
            {
                return i;
            }
        }

        if(current - 1 <0)
        {
            return Mirrors.Length - 1;
        }

        return -1;
    }

    // TODO: handle current mirror is breaking
}
