using TMPro;
using UnityEngine;
using UnityEngine.UI;
using JacobHomanics.Timer;
using UnityEngine.Events;

namespace JacobHomanics.Timer.Extensions
{
    public class CastBar : MonoBehaviour
    {
        [System.Serializable]
        public struct Spell
        {
            public Sprite sprite;
            public string name;
            public float castTime;

            public string action;
        }

        public Spell spell1;
        public Spell spell2;


        public GameObject TimerUI;
        public Timer timer;

        public UnityEvent OnCast;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                Cast(spell1);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                Cast(spell2);

            if (Input.GetKeyDown(KeyCode.Escape))
                CancelCast();

            TimerUI.SetActive(IsCasting);
        }

        public bool IsCasting
        {
            get; private set;
        }

        public void Cast(Spell spell)
        {
            if (!IsCasting)
            {
                Cast(spell.sprite, spell.name, spell.castTime);
                CastingSpell = spell;
            }
        }

        void OnDurationReached()
        {
            Debug.Log(CastingSpell.action);
            IsCasting = false;
        }

        void OnEnable()
        {
            timer.OnDurationReached.AddListener(OnDurationReached);
        }

        void OnDisable()
        {
            timer.OnDurationReached.RemoveListener(OnDurationReached);
        }

        public Spell CastingSpell
        {
            get;
            private set;
        }

        public void CancelCast()
        {
            IsCasting = false;
        }

        private void Cast(Sprite sprite, string name, float castTime)
        {
            FindDeepChild(TimerUI.transform, "Image").GetComponent<Image>().sprite = sprite;
            FindDeepChild(TimerUI.transform, "Spell Indicator Text").GetComponent<TMP_Text>().text = name;
            timer.Duration = castTime;
            timer.ElapsedTime = 0;
            timer.enabled = true;
            IsCasting = true;
        }

        private Transform FindDeepChild(Transform parent, string name)
        {
            foreach (Transform child in parent)
            {
                if (child.name == name)
                    return child;

                var result = FindDeepChild(child, name);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}


