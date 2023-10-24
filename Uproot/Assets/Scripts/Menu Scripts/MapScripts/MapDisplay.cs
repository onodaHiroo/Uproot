using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text mapName;
    [SerializeField] private TMP_Text mapDescription;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockImage;

    private float maxScore;

    public void DisplayMap(Map map)
    {
        mapName.text = map.mapName;
        mapDescription.text = map.mapDescription;
        mapImage.sprite = map.mapImage;

        bool mapUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= map.mapIndex;

        lockImage.SetActive(!mapUnlocked);
        playButton.interactable = mapUnlocked;

        if (mapUnlocked)
        {
            mapImage.color = Color.white;
        }
        else
        {
            mapImage.color = Color.grey;
        }

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => SceneManager.LoadScene(map.sceneToLoad.name));

        if (PlayerPrefs.HasKey($"maxScoreLevel{map.mapIndex}"))
        {
            maxScore = PlayerPrefs.GetFloat($"maxScoreLevel{map.mapIndex}", maxScore);
            map.mapDescription = $"Max Score: {maxScore}";

            Debug.Log($"MapIndex: {map.mapIndex}\nMaxScore:{maxScore}");
        }
        else
        {
            map.mapDescription = $"Max Score: {0}";
        }
            
    }
}
