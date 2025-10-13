using UnityEngine;
using TMPro;

public class LoadTextx : MonoBehaviour
{

    [SerializeField] string[] messagesset1 = new string[3];
    [SerializeField] string[] messagesset2 = new string[3];
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
        messagesset2[0] = "Oopss we forgot something:).";
        messagesset2[1] = "Oopss we forgot something:)..";
        messagesset2[2] = "Oopss we forgot something:)...";
    }

    void Update()
    {
        Timer = Timer + Time.deltaTime * Speed;
        if (Timer >= 8f)
        {
            ChangeTextForLoad(messagesset2);
        }
        else
        {
            ChangeTextForLoad(messagesset1);
        }
        
        if (Timer >= 17f)
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
