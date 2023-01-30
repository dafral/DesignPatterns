using System;

namespace Patterns.Observer
{
    public interface ISkill
    {
        public event Action<int> OnChargesUpdated;
        public event Action<bool> OnIsReadyUpdated;

        void Use();
    }
}
