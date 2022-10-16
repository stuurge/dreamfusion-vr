using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropdownManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Dropdown dropDown;
    public Toggle toggle;
    public List<string> names = new List<string>();
    public string[] dirs;
    public int selectedIndex;
    public bool planetMode;
    private Scene scene;
    void Awake()
    {

        dirs = Directory.GetDirectories(Application.dataPath + "/../" + "models/meshes");

        names.Add("");
        foreach (string d in dirs) {
            var x = Path.GetFileName(d);
            names.Add(x);
            Debug.Log(x);
        }

        Debug.Log(dirs);
        //dropDown = GetComponent<TMP_Dropdown>();

        dropDown.ClearOptions();
        dropDown.AddOptions(names);
        DontDestroyOnLoad(this.gameObject);

        scene = SceneManager.GetActiveScene();
    }



    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    if (!string.Equals(scene.path, this.scene.path)) return;

    //    Debug.Log("Re-Initializing", this);

    //    //Instantiate(objManager, new Vector3(0,0,0), Quaternion.identity);
    //   var  x = SceneManager.GetActiveScene().name;
    //    Debug.Log(x);
    //}

    public void GetVal()
    {
        Debug.Log(dropDown.value);
        selectedIndex = dropDown.value;
    }

    public void GetMode()
    {
        planetMode = toggle.isOn;
        Debug.Log(planetMode);
    }
    public void SceneSwap()
    {
        if (scene.name == "StartScene" && !toggle.isOn)
        {
            SceneManager.LoadScene("Object Room");

        } else
        {
            SceneManager.LoadScene("PlanetScene");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
