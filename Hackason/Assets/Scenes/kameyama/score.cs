using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう
using TMPro;  // TextMeshProの名前空間をインポートする
public class score : MonoBehaviour
{
     public int scorePoint;
      public GameObject score_object = null; // Textオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          // オブジェクトからTextコンポーネントを取得
       TextMeshProUGUI score_text = score_object.GetComponent<TextMeshProUGUI>();
        // テキストの表示を入れ替える
        score_text.text = scorePoint.ToString();
                  if (Input.GetKey(KeyCode.Backspace)){
            AddScore(10);
          }
    }
    public void AddScore(int num){
        scorePoint+=num;
        if(scorePoint>=1000){
            gameObject.GetComponent<sceneManager>().OnLoadSceneSingle();
        }
    }
}
