using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Start.Base;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] private BaseObject[] baseObjects;
    private ScoreController _scoreController;
    private UIController _uiController;

    private void Awake()
    {
        _scoreController = baseObjects[1].GetComponent<ScoreController>();
        _uiController = baseObjects[0].GetComponent<UIController>();
        Application.targetFrameRate = 60;
        SingletonPattern();
        CallBaseObjectAwakes();
        LoadGame();
    }
    

    private void Start()
    {
        CallBaseObjectStarts();
    }

    private void Update()
    {
        CallBaseObjectUpdates();
    }

    private void FixedUpdate()
    {
        CallBaseObjectFixedUpdates();
    }
    
    private void LateUpdate()
    {
        CallBaseObjectLateUpdates();
    }

    
    private void OnDestroy()
    {
       SaveGame();
       CallBaseObjectDestroys();
    }

    private void CallBaseObjectAwakes()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectAwake();
        }
    }

    private void CallBaseObjectStarts()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectStart();
        }
    }

    private void CallBaseObjectUpdates()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectUpdate();
        }
    }

    private void CallBaseObjectFixedUpdates()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectFixedUpdate();
        }
    }

    private void CallBaseObjectLateUpdates()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectLateUpdate();
        }
    }


    private void CallBaseObjectDestroys()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectDestroy();
        }
    }
    
    private void SingletonPattern()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave"))
        {
            //Debug.Log("wtf bro");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave", FileMode.Open);
            SaveDatas savedDatas = (SaveDatas) bf.Deserialize(file);
            file.Close();
            
            _scoreController.SetHighScore(savedDatas.GetSavedHighScore());
        }

        else
        {
            Debug.Log("no game saved");
        }
    }

    private SaveDatas CreateSaveGameObject()
    {
        SaveDatas saveDatas = new SaveDatas();
        saveDatas.SetSavedHighScore();

        return saveDatas;
    }

    public void SaveGame()
    {
        SaveDatas saveDatas = CreateSaveGameObject();
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave");
        bf.Serialize(file,saveDatas);
        file.Close();
        
    }

    

    public UIController GetUIController()
    {
        return _uiController;
    }
    
    public ScoreController GetScoreController()
    {
        return _scoreController;
    }

    public BaseObject GetBaseObject(int index)
    {
        return baseObjects[index];
    }
    
    
}