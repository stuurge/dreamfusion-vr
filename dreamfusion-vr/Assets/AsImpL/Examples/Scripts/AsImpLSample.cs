using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor;

namespace AsImpL
{
    namespace Examples
    {
        /// <summary>
        /// Demonstrate how to load a model with ObjectImporter.
        /// </summary>
        public class AsImpLSample : MonoBehaviour
        {
            [SerializeField]
            public string filePath = "models/OBJ_test/mesh.obj";

            [SerializeField]
            protected string objectName = "MyObject";

            [SerializeField]
            protected ImportOptions importOptions = new ImportOptions();

            [SerializeField]
            protected PathSettings pathSettings;

            protected ObjectImporter objImporter;

            private DropdownManager man;

            [SerializeField]
            public TMP_Text object_name;

            public GameObject wall_obj1;
            public GameObject wall_obj2;

            private void Awake()
            {
                man = GameObject.Find("Persistent Manager").GetComponent<DropdownManager>();
                string name = man.names[man.selectedIndex];
                object_name.text = name;
                Debug.Log(name);
                filePath = "models/meshes/" + name + "/mesh.obj";

                filePath = pathSettings.RootPath + filePath;

                string imgPath = pathSettings.RootPath + "models/meshes/" + name + "/albedo.png";
                Texture2D tex = LoadPNG(imgPath);
                Debug.Log(tex);

                var material = new Material(Shader.Find("Unlit/Texture"));
                material.mainTexture = (Texture)tex;

                wall_obj1.GetComponent<Renderer>().material = material;
                wall_obj2.GetComponent<Renderer>().material = material;


                if (objImporter == null)
                {
                    
                    objImporter = gameObject.AddComponent<ObjectImporter>();
                }
            }

            public Texture2D LoadPNG(string imgPath)
            {
                Texture2D tex = null;
                byte[] imgData;

                if (File.Exists(imgPath))
                {
                    imgData = File.ReadAllBytes(imgPath);
                    tex = new Texture2D(2, 2);
                    tex.LoadImage(imgData);
                }
                return tex;
            }

            void Start()
            {
                objImporter.ImportModelAsync(objectName, filePath, null, importOptions);
            }


            private void OnValidate()
            {
                if(pathSettings==null)
                {
                    pathSettings = PathSettings.FindPathComponent(gameObject);
                }
            }

        }
    }
}
