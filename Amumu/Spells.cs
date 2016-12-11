using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Amumu
{
    internal class Spells
    {
        public static Spell.Skillshot Q;
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Active R;

        public static void LoadSpells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 1100, SkillShotType.Linear);
            W = new Spell.Active(SpellSlot.W, 300, DamageType.Magical);
            E = new Spell.Active(SpellSlot.E, 350, DamageType.Magical);
            R = new Spell.Active(SpellSlot.R, 550, DamageType.Magical);            
        }
    }
}
