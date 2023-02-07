using Core.Services;
using UnityEngine;

namespace Core
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(ServiceLocator serviceLocator);
    }
}