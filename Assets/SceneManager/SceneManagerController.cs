using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    void Start ()
    {
        GameObject obj = GameObject.Find("SceneManager");
        if (obj && obj != gameObject) { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
        }
    }
	
    static public void Change()
    {
        //カーソルの画像をTexture、ホットスポットをhotspot、表示をForceSoftware(ソフトウェアカーソルを使用)に設定
        Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.ForceSoftware);
        
        int current = SceneManager.GetActiveScene().buildIndex + 1;
        if (current > 2) { current = 0; }
        SceneManager.LoadScene(current);
    }
}
