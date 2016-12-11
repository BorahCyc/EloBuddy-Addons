using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace Amumu
{
    class Combo
    {
        public static void ComboExecute()
        {
            if (AddonMenu.ComboMenu["useQ"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (target != null && target.IsValidTarget())
                {
                    var Qpred = Spells.Q.GetPrediction(target);
                    if (Qpred.HitChancePercent >= 80)
                    {
                        Spells.Q.Cast(Qpred.CastPosition);
                    }                  
                }
            }
        }
    }
}
