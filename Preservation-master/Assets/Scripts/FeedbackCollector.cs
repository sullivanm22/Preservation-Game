////////////////////////////////////////
//
//      Collecting Feedback
//      by Matthew Ventures
//    mrventures.net/gamedevlearn
//
////////////////////////////////////////

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FeedbackCollector : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI txtData;
    [SerializeField] private UnityEngine.UI.Button btnSubmit;
    [SerializeField] private CollectionOption option;

    private enum CollectionOption { openEmailClient, openGFormLink, sendGFormData };

    private const string kReceiverEmailAddress = "me@gmail.com";

    private const string kGFormBaseURL = "https://docs.google.com/forms/d/e/1FAIpQLSchQzdbNs_wY_EWSpAtohQHRDQeliy0o6yLoRs7C5D17B-1qg/";
    private const string kGFormEntryID = "entry.1330939643";

    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(txtData);
        UnityEngine.Assertions.Assert.IsNotNull(btnSubmit);
        btnSubmit.onClick.AddListener(delegate {
            switch (option)
            {
                case CollectionOption.openEmailClient:
                    OpenEmailClient(txtData.text);
                    break;
                case CollectionOption.openGFormLink:
                    OpenGFormLink();
                    break;
                case CollectionOption.sendGFormData:
                    StartCoroutine(SendGFormData(txtData.text));
                    break;
            }
        });
    }

    private static void OpenEmailClient(string feedback)
    {
        string email = kReceiverEmailAddress;
        string subject = "Feedback";
        string body = "<" + feedback + ">";
        OpenLink("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }

    private static void OpenGFormLink()
    {
        string urlGFormView = kGFormBaseURL + "viewform";
        OpenLink(urlGFormView);
    }

    private static IEnumerator SendGFormData<T>(T dataContainer)
    {
        bool isString = dataContainer is string;
        string jsonData = isString ? dataContainer.ToString() : JsonUtility.ToJson(dataContainer);

        WWWForm form = new WWWForm();
        form.AddField(kGFormEntryID, jsonData);
        string urlGFormResponse = kGFormBaseURL + "formResponse";
        using (UnityWebRequest www = UnityWebRequest.Post(urlGFormResponse, form))
        {
            yield return www.SendWebRequest();
        }
    }

    // We cannot have spaces in links for iOS
    public static void OpenLink(string link)
    {
        bool googleSearch = link.Contains("google.com/search");
        string linkNoSpaces = link.Replace(" ", googleSearch ? "+" : "%20");
        Application.OpenURL(linkNoSpaces);
    }
}



