using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private MenuUIManager menuUIManager;
    [SerializeField] private MenuData menuData;

    private void Start()
    {
        menuData.Initialize();
        menuUIManager.Initialize();
    }
}
