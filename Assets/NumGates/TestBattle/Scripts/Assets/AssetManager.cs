using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace NumGates.TestBattle
{
    public class AssetManager : MonoBehaviour
    {
        public static AssetManager instance;

        public Action OnLoadComplete;

        //private AssetLoader assetLoader;
        [Header("Asset Loader")]
        [SerializeField] private AssetLoaderUI assetLoaderUI;
        [SerializeField] private AssetLoaderAlly assetLoaderAlly;
        [SerializeField] private AssetLoaderEnemy assetLoaderEnemy;

        [Header("UI Reference")]
        [SerializeField] private AssetLabelReference uiLable;
        [SerializeField] private AssetReference uiFloatingText;
        [SerializeField] private AssetReference uiBattleEvent;

        [Header("Character Reference")]
        [SerializeField] private AssetLabelReference allyLable;
        [SerializeField] private AssetLabelReference enemyLable;

        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.

            if (instance != null && instance != this)
            {
                Destroy(this);
            }

            instance = this;
            DontDestroyOnLoad(instance);
        }

        private void Start()
        {
            //StartCoroutine(assetLoaderUI.LoadAssets(uiLable));
            //StartCoroutine(assetLoaderAlly.LoadAssets(allyLable));
            //StartCoroutine(assetLoaderEnemy.LoadAssets(enemyLable));

        }

        private void Update()
        {

        }

        public IEnumerator InitAssets()
        {
            yield return StartCoroutine(assetLoaderUI.LoadAssets(uiLable));
            yield return StartCoroutine(assetLoaderAlly.LoadAssets(allyLable));
            yield return StartCoroutine(assetLoaderEnemy.LoadAssets(enemyLable));

            OnLoadComplete?.Invoke();
        }

        #region UI Asset

        public UIFloatingText GetUIFloatingText() => assetLoaderUI.GetAsset(uiFloatingText.AssetGUID).GetComponent<UIFloatingText>();
        public UIBattleEvent GetUIBattleEvent() => assetLoaderUI.GetAsset(uiBattleEvent.AssetGUID).GetComponent<UIBattleEvent>();

        #endregion

        #region Character Asset

        public GameObject GetAllyCharacter(CharacterAlly ally) => assetLoaderAlly.GetAsset(ally);
        public GameObject GetEnemyCharacter(CharacterEnemy enemy) => assetLoaderEnemy.GetAsset(enemy);

        #endregion
    }
}

