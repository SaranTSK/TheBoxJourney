using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumGates.TestBattle
{
    public class LevelManager : MonoBehaviour
    {
        public TimerManager TimerManager => timeManager;
        [SerializeField] private TimerManager timeManager;

        public BattleManager BattleManager => battleManager;
        [SerializeField] private BattleManager battleManager;

        private void Start()
        {
            InitManager();
        }

        private void Update()
        {
            
        }

        public void InitManager()
        {
            Instantiate(timeManager);
            Instantiate(battleManager);
        }

        public void DestroyManager()
        {
            Destroy(timeManager);
            Destroy(battleManager);
        }
    }
}

