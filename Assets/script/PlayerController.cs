using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed; // 動く速さ
    public Text scoreText; // スコアの UI
    public Text winText; // リザルトの UI

    private Rigidbody rb; // Rididbody
    private int score; // スコア


    void Start() {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        // UI を初期化
        score = 0;
        SetCountText();
        winText.text = "";
    }

    void Update() {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);

        GameObject[] gameObjs = GameObject.FindGameObjectsWithTag("Pick up");
        foreach (GameObject ball in gameObjs) {
            if (ball != null) {
                Vector3 tmp = ball.transform.position;
                float y = tmp.y;

                if (y < -10) {
                    Debug.Log("here");

                    // スコアを加算します
                    score = score + 1;

                    // UI の表示を更新します
                    SetCountText();
                    Destroy(ball);
                }
            }
        }





    }

    // UI の表示を更新する
    void SetCountText() {
        // スコアの表示を更新
        scoreText.text = "Count: " + score.ToString();

        // すべての収集アイテムを獲得した場合
        if (score >= 10) {
            // リザルトの表示を更新
            winText.text = "You Win!";
        }
    }
}
