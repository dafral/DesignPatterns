using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.ServiceLocator
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private ScoreSystemMonoBehaviour _scoreSystemMonoBehaviour;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService<IScoreSystem>(new ScoreSystem());
            //ServiceLocator.Instance.RegisterService<IScoreSystem>(_scoreSystemMonoBehaviour);
        }
    }
}

