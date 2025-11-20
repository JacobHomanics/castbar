using JacobHomanics.Timer.Extensions;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public TimedAction castbar;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Cast(spell1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            Cast(spell2);

        if (Input.GetKeyDown(KeyCode.Escape))
            castbar.CancelCast();

    }


    public Spell CastingSpell
    {
        get;
        private set;
    }


    void OnEnable()
    {
        castbar.OnTimeComplete.AddListener(OnDurationReached);
    }

    void OnDisable()
    {
        castbar.OnTimeComplete.RemoveListener(OnDurationReached);

    }

    public void Cast(Spell spell)
    {
        castbar.Cast(spell.sprite, spell.name, spell.castTime);
        CastingSpell = spell;
    }


    void OnDurationReached()
    {
        DoSpell();
    }


    void DoSpell()
    {
        Debug.Log(CastingSpell.action);
    }

}
