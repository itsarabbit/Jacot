/*
 * Created by Erik Paldanius
 * 
 * Edits log:
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace BallGame.Engine
{
    enum JoystickButtons
    {
        Down = 0,
        Right,
        Left,
        Up,
        Select,
        Start,
        RightBumper,
        LeftBumper

    }

    static class Input
    {
        private static bool[] isKeyPressed = new bool[(int)Keyboard.Key.KeyCount],
            isKeyDown = new bool[(int)Keyboard.Key.KeyCount],
            isKeyReleased = new bool[(int)Keyboard.Key.KeyCount],
            isKeyTriggered = new bool[(int)Keyboard.Key.KeyCount];

        #region EttStortGängBools
        private static bool[][] isJoyButtonPressed = new bool[32][]
        {
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4]
        };

        private static bool[][] isJoyButtonDown = new bool[32][]
        {
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4]
        };

        private static bool[][] isJoyButtonReleased = new bool[32][]
        {
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4],
            new bool[4]
        };
        #endregion

        private static bool[] isButtonPressed = new bool[(int)Mouse.Button.ButtonCount],
            isButtonDown = new bool[(int)Mouse.Button.ButtonCount],
            isButtonReleased = new bool[(int)Mouse.Button.ButtonCount];

        public static Vector2f MousePosition { get; private set; }
        public static Vector2i MousePositionI { get { return new Vector2i((int)MousePosition.X, (int)MousePosition.Y); } }

        public static float MouseX { get { return MousePosition.X; } }
        public static float MouseY { get { return MousePosition.Y; } }

        public static Vector2f[] JoystickPosition = new Vector2f[4];
        
            /*new Vector2f(Joystick.GetAxisPosition(0, Joystick.Axis.X), Joystick.GetAxisPosition(0, Joystick.Axis.Y)),
            new Vector2f(Joystick.GetAxisPosition(1, Joystick.Axis.X), Joystick.GetAxisPosition(1, Joystick.Axis.Y)),
            new Vector2f(Joystick.GetAxisPosition(2, Joystick.Axis.X), Joystick.GetAxisPosition(2, Joystick.Axis.Y)),
            new Vector2f(Joystick.GetAxisPosition(3, Joystick.Axis.X), Joystick.GetAxisPosition(3, Joystick.Axis.Y))*/


        //public static Vector2f MouseWorldPos { get { return Game.RenderWindow.MapPixelToCoords(MousePositionI, Game.WorldView.SfmlView); } }

        public static string Text = "";

        public static void Press(Keyboard.Key key)
        {
            int code = (int)key;
            isKeyTriggered[code] = true;
            if (!isKeyDown[code])
            {
                isKeyDown[code] = true;
                isKeyPressed[code] = true;
                isKeyReleased[code] = false;
            }
        }

        public static void Release(Keyboard.Key key)
        {
            int code = (int)key;
            if (isKeyDown[code])
            {
                isKeyPressed[code] = false;
                isKeyDown[code] = false;
                isKeyReleased[code] = true;
            }
        }

        public static void Press(Mouse.Button button)
        {
            int code = (int)button;
            if (!isButtonDown[code])
            {
                isButtonDown[code] = true;
                isButtonPressed[code] = true;
                isButtonReleased[code] = false;
            }
        }

        public static void Release(Mouse.Button button)
        {
            int code = (int)button;
            if (isButtonDown[code])
            {
                isButtonDown[code] = false;
                isButtonPressed[code] = false;
                isButtonReleased[code] = true;
            }
        }

        public static void Press(uint controllerIndex, uint code)
        {
            if (!isJoyButtonDown[code][controllerIndex])
            {
                isJoyButtonDown[code][controllerIndex] = true;
                isJoyButtonPressed[code][controllerIndex] = true;
                isJoyButtonReleased[code][controllerIndex] = false;
            }
        }

        public static void Release(uint controllerIndex, uint code)
        {
            if (isJoyButtonDown[code][controllerIndex])
            {
                isJoyButtonPressed[code][controllerIndex] = false;
                isJoyButtonDown[code][controllerIndex] = false;
                isJoyButtonReleased[code][controllerIndex] = true;
            }
        }

        public static void Update()
        {
            int bla = (int)Joystick.ButtonCount;
            Joystick.Update();
            JoystickPosition[0] = -new Vector2f(Joystick.GetAxisPosition(0, Joystick.Axis.X), Joystick.GetAxisPosition(0, Joystick.Axis.Y));
            JoystickPosition[1] = -new Vector2f(Joystick.GetAxisPosition(1, Joystick.Axis.X), Joystick.GetAxisPosition(1, Joystick.Axis.Y));
            JoystickPosition[2] = -new Vector2f(Joystick.GetAxisPosition(2, Joystick.Axis.X), Joystick.GetAxisPosition(2, Joystick.Axis.Y));
            JoystickPosition[3] = -new Vector2f(Joystick.GetAxisPosition(3, Joystick.Axis.X), Joystick.GetAxisPosition(3, Joystick.Axis.Y));

            Vector2i mp = Mouse.GetPosition(Game.Window);
            MousePosition = new Vector2f((float)mp.X, (float)mp.Y);

            for (int i = 0; i < (int)Keyboard.Key.KeyCount; i++)
            {
                isKeyTriggered[i] = false;
                isKeyPressed[i] = false;
                isKeyReleased[i] = false;

                if (isKeyDown[i])
                {
                    if (!Keyboard.IsKeyPressed((Keyboard.Key)i))
                    {
                        Release((Keyboard.Key)i);
                    }
                }
            }
            for (int i = 0; i < (int)Mouse.Button.ButtonCount; i++)
            {
                isButtonPressed[i] = false;
                isButtonReleased[i] = false;

                if (isButtonDown[i])
                {
                    if (!Mouse.IsButtonPressed((Mouse.Button)i))
                    {
                        Release((Mouse.Button)i);
                    }
                }
            }
            for (int u = 0; u < 4; u++)
            {
                for (int i = 0; i < (int)Joystick.ButtonCount; i++)
                {
                    isJoyButtonPressed[i][u] = false;
                    isJoyButtonReleased[i][u] = false;

                    if (isJoyButtonDown[i][u])
                    {
                        if (!Joystick.IsButtonPressed((uint)u, (uint)i))
                        {
                            Release((uint)u, (uint)i);
                        }
                    }
                }
            }
        }

        public static bool IsDown(Keyboard.Key key)
        {
            return isKeyDown[(int)key];
        }

        public static bool IsPressed(Keyboard.Key key)
        {
            return isKeyPressed[(int)key];
        }

        public static bool IsTriggered(Keyboard.Key key)
        {
            return isKeyTriggered[(int)key];
        }

        public static bool IsReleased(Keyboard.Key key)
        {
            return isKeyReleased[(int)key];
        }

        public static bool IsDown(Mouse.Button button)
        {
            return isButtonDown[(int)button];
        }

        public static bool IsPressed(Mouse.Button button)
        {
            return isButtonPressed[(int)button];
        }

        public static bool IsReleased(Mouse.Button button)
        {
            return isButtonReleased[(int)button];
        }

        public static bool IsDown(uint index, JoystickButtons button)
        {
            return isJoyButtonDown[(int)button][index];
        }

        public static bool IsPressed(uint index, JoystickButtons button)
        {
            int code = (int)button;
            return isJoyButtonPressed[(int)button][index];
        }

        public static bool IsReleased(uint index, JoystickButtons button)
        {
            return isJoyButtonReleased[(int)button][index];
        }

        public static bool MouseIsOn(FloatRect rect)
        {
            return (MouseX >= rect.Left && MouseY >= rect.Top && MouseX < rect.Left + rect.Width && MouseY < rect.Top + rect.Height);
        }

        public static void OnTextEntered(char character)
        {
            if (!char.IsControl(character))
            {
                Text += character;
            }
            else
            {
                if (character == (char)8)
                    if (Text.Length > 0)
                        Text = Text.Remove(Text.Length - 1, 1);
            }
        }

        public static void RegisterEvents(RenderWindow window)
        {
            window.KeyPressed += (sender, args) =>
            {
                if (args.Code != Keyboard.Key.Unknown)
                {
                    Press(args.Code);
                }
            };

            window.TextEntered += (sender, args) =>
            {
                OnTextEntered(args.Unicode[0]);
            };

            window.JoystickButtonPressed += (sender, args) =>
            {
                Press(args.JoystickId, args.Button);
            };

           window.MouseButtonPressed += (sender, args) =>
            {
                Press(args.Button);
            };

            /*window.GainedFocus += (sender, args) => { Game.HasFocus = true; };
            window.LostFocus += (sender, args) => { Game.HasFocus = false; };*/


            window.Closed += (sender, args) => { window.Close(); };
        }
    }
}
