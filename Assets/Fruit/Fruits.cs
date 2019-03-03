using UnityEngine;

public class Fruits : MonoBehaviour
{
	public GameObject Prefab { get; set; }
	public string FruitName { get; internal set; }
	/// <summary>
	/// ドラッグ中
	/// </summary>
	public bool Dragging { get; private set; }
	/// <summary>
	/// デフォ位置
	/// </summary>
	private Vector3 DefPos { get; set; }
	/// <summary>
	/// ミキサーに入っているかどうか
	/// </summary>
	private bool InMixer { get; set; }
	/// <summary>
	/// ミキサーゲームオブジェクト
	/// </summary>
	private GameObject goMixer { get; set; }
	/// <summary>
	/// ミキサー
	/// </summary>
	private Mixer Mixer { get; set; }
	/// <summary>
	/// 種類
	/// </summary>
	public FruitType Type { get; internal set; }
	/// <summary>
	/// コスト
	/// </summary>
	public int Cost { get; internal set; }
	/// <summary>
	/// フルーツの名前
	/// </summary>
	protected string spriteName_;

	private void Awake()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		Sprite sprite = Resources.Load<Sprite>("Fruit/" + spriteName_);
		if (sprite && spriteRenderer)
		{
			spriteRenderer.sprite = sprite;
		}

		Dragging = false;
		DefPos = transform.position;
		InMixer = false;
		Prefab = GameObject.Find(FruitName);
		goMixer = GameObject.Find("mixer");
		Mixer = goMixer.GetComponent<Mixer>();
	}

	private void FixedUpdate()
	{
		// ドラッグ中の場合は位置更新
		if (Dragging)
		{
			//float x = Input.GetAxis("Mouse X");
			//float y = Input.GetAxis("Mouse Y");
			//transform.Translate(x / Screen.width * 1280, y / Screen.height * 720, 0, Space.World);

            // Vector3でマウス位置座標を取得する
            Vector3 position = Input.mousePosition;
            // Z軸修正
            position.z = 10f;
            // マウス位置座標をスクリーン座標からワールド座標に変換する
            Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
            // ワールド座標に変換されたマウス座標を代入
            gameObject.transform.position = screenToWorldPointPosition;
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// ミキサーに入ったらフラグを立てる
		if (collision.gameObject.CompareTag("Mixer"))
		{
			InMixer = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		// ミキサーから出たらフラグを倒す
		if (collision.gameObject.CompareTag("Mixer"))
		{
			InMixer = false;
		}
	}

	// ドラッグ開始した時の処理
	public void StartDrag()
	{
		Dragging = true;
	}

	// ドラッグ終了したときの処理
	// 位置を初期位置に戻す
	public void EndDrag()
	{
		// ミキサー内であればミキサーにフルーツを足す
		if (InMixer)
		{
			GameObject addedInMixer = Instantiate(Prefab, transform.position, transform.rotation);
			Mixer.tempFruits.Add(addedInMixer);
			Mixer.AddFruit(this);
		}
		Dragging = false;
		transform.position = DefPos;
	}
}
