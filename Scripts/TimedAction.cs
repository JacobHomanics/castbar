using UnityEngine;
using UnityEngine.Events;

namespace JacobHomanics.Timer.Extensions
{
    public class TimedAction : MonoBehaviour
    {
        public Timer timer;

        public bool allowSelfInterruption = false;

        public UnityEvent<Sprite, string> OnCast;

        public bool IsCasting
        {
            get => timer.enabled;
        }

        public bool CanStartCast
        {
            get => !IsCasting || allowSelfInterruption;
        }

        public UnityEvent OnTimeComplete;


        void OnEnable()
        {
            timer.OnDurationReached.AddListener(OnDurationReached);
        }

        void OnDisable()
        {
            timer.OnDurationReached.RemoveListener(OnDurationReached);
        }

        public void Cast(Sprite sprite, string name, float castTime)
        {
            if (!CanStartCast)
                return;

            timer.Duration = castTime;
            timer.ElapsedTime = 0;
            timer.enabled = true;
            OnCast?.Invoke(sprite, name);
        }

        public void CancelCast()
        {
            timer.enabled = false;
        }

        void OnDurationReached()
        {
            timer.enabled = false;
            OnTimeComplete.Invoke();
        }

    }
}


