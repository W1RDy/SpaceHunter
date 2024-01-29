using UnityEngine;

public class SceneController : MonoBehaviour
{
    SceneModel scene;
    void Start() => scene = GetComponent<SceneModel>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) scene.Pause();    
    }
}
