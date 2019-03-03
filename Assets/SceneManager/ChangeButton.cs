using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManagerController.Change();
    }
}
