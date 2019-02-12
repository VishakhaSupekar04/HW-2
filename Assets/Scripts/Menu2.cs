using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(60, 60, 100, 50), "Menu"))
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel(0);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

}
