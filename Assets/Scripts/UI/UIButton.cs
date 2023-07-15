using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    private Button _btn;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClick);
    }

    public virtual void OnClick()
    {
        SFXManager.Instance.PlayUIClick();
    }
}
