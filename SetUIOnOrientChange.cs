using System.Collections.Generic;
using UnityEngine;

public class SetUIOnOrientChange : MonoBehaviour
{
    [SerializeField] bool onValidateChange;
    [SerializeField] List<RectTransform> uiObjects;
    [SerializeField] List<Vector3> landPos;
    [SerializeField] List<Vector3> portPos;

    //private void Start()
    //{
    //    GlobalVeriler.ins.OnOrientationChanged += ChangePos;
    //}


    //private void OnDisable()
    //{
    //    GlobalVeriler.ins.OnOrientationChanged -= ChangePos;

    //}

    private void OnValidate()
    {
        ChangePos(Screen.orientation);
    }


     void ChangePos(ScreenOrientation so)
    {
        if (so == ScreenOrientation.Portrait)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                uiObjects[i].anchoredPosition = portPos[i];
            }
        }
        else
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                uiObjects[i].anchoredPosition = landPos[i];
            }
        }
    }
}
