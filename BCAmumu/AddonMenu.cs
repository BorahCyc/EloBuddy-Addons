using System.Drawing;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace BCAmumu
{
    class AddonMenu
    {
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu LaneClear;
        public static Menu JungleClear;
        public static Menu KillSteal;
        public static Menu DrawMenu;

        public static void DesignMenu()
        {
            FirstMenu = MainMenu.AddMenu("Amumu", "Amumu");
            FirstMenu.AddGroupLabel("Made by Borah Cyc!");
            FirstMenu.AddLabel("Test & Give me your feedback!");

            ComboMenu = FirstMenu.AddSubMenu("Combo");
            {
                ComboMenu.AddGroupLabel("Combo Settings");
                ComboMenu.Add("Qcb", new CheckBox("Use Q"));
                ComboMenu.Add("Wcb", new ComboBox("W style", 2, "Don't use W", "W Normal", "W Spam =)))"));
                ComboMenu.Add("Ecb", new CheckBox("Use E"));
                ComboMenu.Add("Rcb", new CheckBox("Use R"));
                ComboMenu.Add("RcbENM", new Slider("Use R if {0} enemies in range", 0, 2, 5));
            }

            LaneClear = FirstMenu.AddSubMenu("LaneClear");
            {
                LaneClear.AddGroupLabel("LaneClear Settings");
                LaneClear.Add("Qlc", new CheckBox("Use Q"));
                LaneClear.Add("Wlc", new CheckBox("Use W"));
                LaneClear.Add("Elc", new CheckBox("Use E"));
                LaneClear.Add("ManaMNGlc", new Slider("If mana percent below {0}% stop", 45, 0, 100));
            }

            JungleClear = FirstMenu.AddSubMenu("JungleClear");
            {
                JungleClear.AddGroupLabel("JungleClear Settings");
                JungleClear.Add("Qjc", new CheckBox("Use Q"));
                JungleClear.Add("Wjc", new CheckBox("Use W"));
                JungleClear.Add("Ejc", new CheckBox("Use E"));
                JungleClear.Add("ManaMNGjc", new Slider("If mana percent below {0}% stop", 45, 0, 100));
            }

            KillSteal = FirstMenu.AddSubMenu("KillSteal");
            {
                KillSteal.AddGroupLabel("KillSteal Settings");
                KillSteal.Add("Qks", new CheckBox("Use Q"));
                KillSteal.Add("Wks", new CheckBox("Use E"));
                KillSteal.Add("Rks", new CheckBox("Use R"));
            }

            DrawMenu = FirstMenu.AddSubMenu("Drawings");
            {
                DrawMenu.AddGroupLabel("Draw Settings");
                DrawMenu.Add("enadr", new CheckBox("Enable Drawings"));
                DrawMenu.Add("Qdr", new CheckBox("Draw Q"));
                DrawMenu.Add("Wdr", new CheckBox("Draw W"));
                DrawMenu.Add("Edr", new CheckBox("Draw E"));
                DrawMenu.Add("Rdr", new CheckBox("Draw R"));
                DrawMenu.Add("coldr", new CheckBox("Draw Damage Indicator"));
                DrawMenu.Add("Color", new ColorPicker("Damage Indicator Color", Color.FromArgb(255, 255, 236, 0)));
            }
        }

    }
}