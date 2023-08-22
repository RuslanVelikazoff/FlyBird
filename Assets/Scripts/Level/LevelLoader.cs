using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private LevelUIManager levelUIManager;
    [SerializeField] private CameraScaller cameraScaller;
    [SerializeField] private StartData data;

    private void Start()
    {
        data.Initialize();
        cameraScaller.Initialize();
        spawner.Initialize();
        player.Initialize();
        levelUIManager.Initialize();
        scoreManager.Initialize();
    }
}
