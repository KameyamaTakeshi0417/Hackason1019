using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager: MonoBehaviour
{
    public string nextscene;
    public void OnLoadSceneSingle()
    {
        //SceneBをロード。現在のシーンは自動的に削除されて、シーンBだけになる
        SceneManager.LoadScene(nextscene);
    }

}