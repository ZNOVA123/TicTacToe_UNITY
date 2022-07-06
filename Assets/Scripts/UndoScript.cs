using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoScript : MonoBehaviour
{
    void OnMouseDown()
    {
        TextScript.MoveBack();
    }
}
