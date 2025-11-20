using UnityEngine;
using UnityEngine.Events;

namespace JacobHomanics.Timer.Extensions
{
    public class TimedAction : MonoBehaviour
    {
        public UnityEvent<Sprite, string> OnCast;

        public GameObject TimerUI;
        public Timer timer;

        public bool IsCasting
        {
            get => timer.enabled;
        }

        public UnityEvent OnTimeComplete;

        void OnDurationReached()
        {
            timer.enabled = false;
            OnTimeComplete.Invoke();
        }


        void OnEnable()
        {
            timer.OnDurationReached.AddListener(OnDurationReached);
        }

        void OnDisable()
        {
            timer.OnDurationReached.RemoveListener(OnDurationReached);
        }


        public void CancelCast()
        {
            timer.enabled = false;
        }

        public void Cast(Sprite sprite, string name, float castTime)
        {
            if (IsCasting)
                return;

            timer.Duration = castTime;
            timer.ElapsedTime = 0;
            timer.enabled = true;
            OnCast?.Invoke(sprite, name);
        }
    }
}


