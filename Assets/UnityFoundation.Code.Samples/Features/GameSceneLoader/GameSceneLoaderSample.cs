using UnityEngine;

namespace UnityFoundation.Code.Features.Sample
{
    public class GameSceneLoaderSample : MonoBehaviour
    {
        [SerializeField] private GameSceneLoader initialLoader;
        [SerializeField] private GameObject mainScene2Button;

        public void Start()
        {
            mainScene2Button.SetActive(false);
            initialLoader.OnAllScenesLoaded += EnableNextMainScene;
        }

        private void EnableNextMainScene()
        {
            mainScene2Button.SetActive(true);
        }
    }
}