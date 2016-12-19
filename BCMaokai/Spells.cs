using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace BCMaokai
{
    class Spells
    {
        public static Spell.Skillshot Q;
        public static Spell.Targeted W;
        public static Spell.Skillshot E;
        public static Spell.Active R;

        public static void LoadSpells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 600, SkillShotType.Linear, 500, 1200, 100);
            W = new Spell.Targeted(SpellSlot.W, 525);
            E = new Spell.Skillshot(SpellSlot.E, 1100, SkillShotType.Circular, 175, 350, 250);
            R = new Spell.Active(SpellSlot.R, 475);
        }
    }
}
