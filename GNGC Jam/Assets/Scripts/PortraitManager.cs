using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class PortraitManager : MonoBehaviour
{
    public Image portraitImage;

    public Sprite neutral;
    public Sprite wle;
    public Sprite devious;
    public Sprite angry;
    public Sprite shocked;

    public DialogueRunner dialogueRunner;

    void Start()
    {
        dialogueRunner.AddCommandHandler<string>("portrait", ChangePortrait);
    }

    public void ChangePortrait(string expression)
    {
        Debug.Log("Portrait: " + expression);

        switch (expression.ToLower())
        {
            case "neutral":
                portraitImage.sprite = neutral;
                break;

            case "wle":
                portraitImage.sprite = wle;
                break;

            case "angry":
                portraitImage.sprite = angry;
                break;
            
            case "devious":
                portraitImage.sprite = devious;
                break;

            case "shocked":
                portraitImage.sprite = shocked;
                break;
        }
    }

}