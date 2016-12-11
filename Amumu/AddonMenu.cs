using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Amumu
{
    class AddonMenu
    {
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu LaneClear;
        public static Menu JungleClear;
        public static Menu KillSteal;
        public static Menu DrawMenu;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("Amumu", "Amumu");
            FirstMenu.AddGroupLabel("Made by Trí Đẹp Trai");
            FirstMenu.AddLabel("NAME");

            ComboMenu = FirstMenu.AddSubMenu("Combo");
            {
                ComboMenu.AddGroupLabel("Combo Settings");
                ComboMenu.Add("Q", new CheckBox("Use Q"));
                ComboMenu.Add("W", new CheckBox("Use W"));
                ComboMenu.Add("E", new CheckBox("Use E"));
                ComboMenu.Add("R", new CheckBox("Use R"));
                ComboMenu.Add("AutoR", new Slider("Use R if {0} Enemies in Range", 0, 2, 5));
            }

            LaneClear = FirstMenu.AddSubMenu("LaneClear");
            {
                LaneClear.AddGroupLabel("LaneClear Settings");
                LaneClear.Add("Q", new CheckBox("Use Q"));
                LaneClear.Add("W", new CheckBox("Use W"));
                LaneClear.Add("E", new CheckBox("Use E"));
            }

            JungleClear = FirstMenu.AddSubMenu("JungleClear");
            {
                JungleClear.AddGroupLabel("JungleClear Settings");
                JungleClear.Add("Q", new CheckBox("Use Q"));
                JungleClear.Add("W", new CheckBox("Use W"));
                JungleClear.Add("E", new CheckBox("Use E"));
            }

            KillSteal = FirstMenu.AddSubMenu("KillSteal");
            {
                KillSteal.AddGroupLabel("KillSteal Settings");
                KillSteal.Add("Q", new CheckBox("Use Q"));
                KillSteal.Add("W", new CheckBox("Use E"));
                KillSteal.Add("R", new CheckBox("Use R"));
            }

            DrawMenu = FirstMenu.AddSubMenu("Drawings");
            {
                DrawMenu.AddGroupLabel("Draw Settings");
                DrawMenu.Add("Q", new CheckBox("Draw Q"));
                DrawMenu.Add("W", new CheckBox("Draw W"));
                DrawMenu.Add("E", new CheckBox("Draw E"));
                DrawMenu.Add("R", new CheckBox("Draw R"));
            }
        }

    }
}