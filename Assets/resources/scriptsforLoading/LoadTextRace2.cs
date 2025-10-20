using UnityEngine;
using TMPro;

public class LoadTextRace2 : MonoBehaviour
{
    [SerializeField] string[] messagesset1 = new string[3];
    [SerializeField] TextMeshProUGUI LoadText;
    [SerializeField] float Timer;
    [SerializeField] float Speed;
    [SerializeField] float ChangeText;
    [SerializeField] float ChangeTextSpeed;

    void Start()
    {
        messagesset1[0] = "   Loading.";
        messagesset1[1] = "   Loading..";
        messagesset1[2] = "   Loading...";
    }

    void Update()
    {
        Timer = Timer + Time.deltaTime * Speed;
    
        ChangeTextForLoad(messagesset1);
        
        if (Timer >= 3f)
        {
            Invoke("LoadLevel1", 0.1f);
        }

    }

    public void ChangeTextForLoad(string[] messages)
    {
        ChangeText = Mathf.MoveTowards(ChangeText, 3, ChangeTextSpeed * Time.deltaTime);
        for (int i = 0; i < 3; i++)
        {
            if (i == (int)ChangeText)
            {
                LoadText.text = messages[i];
            }
        }

        if (ChangeText >= 3 - 0.0001f)
        {
            ChangeText = 0;
        }
    }

    public void LoadLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
