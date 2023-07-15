using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : UIButton
{
    public override void OnClick()
    {
        base.OnClick();
        UIManager.Instance.MainMenu();
    }
}
