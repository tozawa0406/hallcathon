using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetMouthTexture : MonoBehaviour
{
    const int MAX_TEXTURE = 2;

    Texture2D[] texture_ = new Texture2D[MAX_TEXTURE];
    int         current_ = 0;

	void Start ()
    {
        texture_[0] = (Texture2D)Resources.Load("ration");
        texture_[1] = (Texture2D)Resources.Load("recovery");

        SetTexture(texture_[current_]);
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            current_++;
            if (current_ >= MAX_TEXTURE) { current_ = 0; }

            SetTexture(texture_[current_]);
        }

	}

    /* @brief   テクスチャ設定処理
     * @param   (texture)   設定したいテクスチャ      */
    void SetTexture(Texture2D texture)
    { 
        //ホットスポットを画像中央に設定
        Vector2 hotspot = texture.texelSize * 0.5f;
        //カーソルの画像をTexture、ホットスポットをhotspot、表示をForceSoftware(ソフトウェアカーソルを使用)に設定
        Cursor.SetCursor(texture, hotspot, CursorMode.ForceSoftware);
    }
}
