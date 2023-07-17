using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public struct Credit
{
    public string name;
    public string role;
}

[System.Serializable]
public struct CreditContainer
{
    public List<Credit> credits;
}

public class Credits : MonoBehaviour
{
    [SerializeField] private TMP_Text _credit;
    private List<Credit> _credits;
    private int _iterateCredits;
    private int _totalCredits;
    private string path;
    private string json;

    private void Start()
    {
        path = Path.Combine(Application.streamingAssetsPath, "Credits.json");
#if UNITY_EDITOR
        json = File.ReadAllText(path);
        ReadCreditsFile();
#else 
        StartCoroutine(RequestCreditsFile());
#endif
    }

    private IEnumerator RequestCreditsFile()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(path))
        {
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Succesfully downloaded text");

                json = request.downloadHandler.text;
                Debug.Log("json: " + json);
                ReadCreditsFile();
            }
        }
    }

    private void ReadCreditsFile()
    {
        _iterateCredits = 0;
        CreditContainer creditContainer = JsonUtility.FromJson<CreditContainer>(json);
        _credits = creditContainer.credits;
        _totalCredits = _credits.Count;
        PresentCredits();
    }

    public void PresentCredits()
    {
        _iterateCredits = 0;
        InvokeRepeating(nameof(ShowCredit), 0, 3);
        InvokeRepeating(nameof(CleanCredit), 1.5f, 3);
    }

    private void ShowCredit()
    {
        _credit.text = _credits[_iterateCredits].name + "\n" + _credits[_iterateCredits].role;
    }

    private void CleanCredit()
    {
        _credit.text = "";
        NextCredit();
    }

    private void NextCredit()
    {
        _iterateCredits++;
        if (_iterateCredits == _totalCredits)
        {
            _iterateCredits = 0;
            CancelInvoke();
            UIManager.Instance.MainMenu();
        }
    }
}
