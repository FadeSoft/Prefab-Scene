using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int levelNumber = 1;
    public GameObject openLevel;

    private void Awake()
    {

        if (PlayerPrefs.HasKey("levelnumber"))
        {
            levelNumber = PlayerPrefs.GetInt("levelnumber");
            var level = Instantiate(Resources.Load<GameObject>("level-" + levelNumber));
            openLevel = level;
        }

        else
            openLevel = Instantiate(Resources.Load<GameObject>("level-" + levelNumber));

        if (instance == null)
            instance = this;

        DontDestroyOnLoad(this.gameObject);

    }

    [ContextMenu("LOAD LEVEL")]
    public void LoadNextLevel()
    {
        DeleteLevel();
        levelNumber++;
        var scene = Instantiate(Resources.Load<GameObject>("level-" + levelNumber));
        openLevel = scene;

        PlayerPrefs.SetInt("levelnumber", levelNumber);
        PlayerPrefs.Save();
    }

    public void DeleteLevel()
    {
        if (openLevel != null)
        {
            Destroy(openLevel);

        }
    }
}
