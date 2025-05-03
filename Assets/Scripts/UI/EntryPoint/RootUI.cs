using UnityEngine;
using R3;

public class RootUI : MonoBehaviour
{
    [SerializeField] private Transform _sceneConteinerUI;

    public void Init()
    {

    }

    public void ShowLoadingScreen(Subject<float> subject)
    {

    }

    private void ClearAttachUI()
    {
        int childCount = _sceneConteinerUI.childCount;
        for (int i = 0; i < childCount; i++)
            Destroy(_sceneConteinerUI.GetChild(i).gameObject);
    }

    public void AttachUI(GameObject sceneUI_GO)
    {
        ClearAttachUI();

        sceneUI_GO.transform.SetParent(_sceneConteinerUI, false);
        sceneUI_GO.gameObject.SetActive(true);
    }
}
