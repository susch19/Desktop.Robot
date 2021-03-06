using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Desktop.Robot
{
    public enum Key
    {

        //Characters
        [Keycode(Platform = "OSX", Value = 0x00)]
        A,
        B,
        C,
        [Keycode(Platform = "OSX", Value = 0x02)]
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        [Keycode(Platform = "OSX", Value = 0x01)]
        S,
        T,
        U,
        V,
        X,
        Y,
        Z,

        //Numbers
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,

        //Symbols
        Comma,
        Colon,
        Semicolon,
        Dot,
        Dollar,
        Slash,
        Backslash,
        Percent,
        LessThan,
        GreaterThan,
        QuotationMark,
        OpenParenthesis,
        CloseParenthesis,
        OpenBracket,
        CloseBracked,
        OpenBrace,
        CloseBrace,
        Interrogation,

        //Accents












        [Keycode(Platform = "OSX", Value = 0x37)]
        Command,

        [Keycode(Platform = "OSX", Value = 0x30)]
        [Keycode(Platform = "Windows", Value = 0x09)]
        Tab,
        
        [Keycode(Platform = "OSX", Value = 0x33)]
        [Keycode(Platform = "Windows", Value = 0x2E)]
        Delete,
        
        [Keycode(Platform = "OSX", Value = 0x35)]
        [Keycode(Platform = "Windows", Value = 0x1B)]
        Esc,
        
        [Keycode(Platform = "OSX", Value = 0x38)]
        [Keycode(Platform = "Windows", Value = 0xA0)]
        Shift,

        [Keycode(Platform = "OSX", Value = 0x3A)]
        Option,
        
        [Keycode(Platform = "OSX", Value = 0x3B)]
        [Keycode(Platform = "Windows", Value = 0xA2)]
        Control,

        [Keycode(Platform = "OSX", Value = 0x39)]
        [Keycode(Platform = "Windows", Value = 0x14)]
        CapsLock,

        [Keycode(Platform = "Windows", Value = 0x12)]
        Alt,

        [Keycode(Platform = "Windows", Value = 0x2D)]
        Insert,

        [Keycode(Platform = "OSX", Value = 0x73)]
        [Keycode(Platform = "Windows", Value = 0xAC)]
        Home,

        [Keycode(Platform = "OSX", Value = 0x77)]
        [Keycode(Platform = "Windows", Value = 0x23)]
        End,

        [Keycode(Platform = "OSX", Value = 0x74)]
        [Keycode(Platform = "Windows", Value = 0x21)]
        PageUp,

        [Keycode(Platform = "OSX", Value = 0x79)]
        [Keycode(Platform = "Windows", Value = 0x22)]
        PageDown,

        [Keycode(Platform = "Windows", Value = 0x08)]
        Backspace,

        [Keycode(Platform = "OSX", Value = 0x45)]
        [Keycode(Platform = "Windows", Value = 0xBB)]
        Plus,

        [Keycode(Platform = "OSX", Value = 0x4E)]
        [Keycode(Platform = "Windows", Value = 0xBD)]
        Minus,

        [Keycode(Platform = "Windows", Value = 0x2C)]
        PrintScreen,

        [Keycode(Platform = "Windows", Value = 0x91)]
        ScrollLock,

        [Keycode(Platform = "Windows", Value = 0x90)]
        NumLock,

        [Keycode(Platform = "Windows", Value = 0x13)]
        Pause,

        [Keycode(Platform = "OSX", Value = 0x7A)]
        [Keycode(Platform = "Windows", Value = 0x70)]
        F1,

        [Keycode(Platform = "OSX", Value = 0x78)]
        [Keycode(Platform = "Windows", Value = 0x71)]
        F2,

        [Keycode(Platform = "OSX", Value = 0x63)]
        [Keycode(Platform = "Windows", Value = 0x72)]
        F3,

        [Keycode(Platform = "OSX", Value = 0x76)]
        [Keycode(Platform = "Windows", Value = 0x73)]
        F4,

        [Keycode(Platform = "OSX", Value = 0x60)]
        [Keycode(Platform = "Windows", Value = 0x74)]
        F5,

        [Keycode(Platform = "OSX", Value = 0x61)]
        [Keycode(Platform = "Windows", Value = 0x75)]
        F6,

        [Keycode(Platform = "OSX", Value = 0x62)]
        [Keycode(Platform = "Windows", Value = 0x76)]
        F7,

        [Keycode(Platform = "OSX", Value = 0x64)]
        [Keycode(Platform = "Windows", Value = 0x77)]
        F8,

        [Keycode(Platform = "OSX", Value = 0x65)]
        [Keycode(Platform = "Windows", Value = 0x78)]
        F9,

        [Keycode(Platform = "OSX", Value = 0x6D)]
        [Keycode(Platform = "Windows", Value = 0x79)]
        F10,
        
        [Keycode(Platform = "OSX", Value = 0x67)]
        [Keycode(Platform = "Windows", Value = 0x7A)]
        F11,

        [Keycode(Platform = "OSX", Value = 0x6F)]
        [Keycode(Platform = "Windows", Value = 0x7B)]
        F12,
    }

    public static class KeysExtensions 
    {
        private static Dictionary<string, OSPlatform> MapOS = new Dictionary<string, OSPlatform>
        {
            {"OSX", OSPlatform.OSX},
            {"Linux", OSPlatform.Linux},
            {"Windows", OSPlatform.Windows},
        };

        public static ushort GetKeycode(this Key key)
        {
            var enumType = typeof(Key);
            var memberInfos = enumType.GetMember(key.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo
                .GetCustomAttributes(typeof(KeycodeAttribute), false)
                .Cast<KeycodeAttribute>()
                .ToList();
            try
            {
                var keycode = valueAttributes
                    .First(k => RuntimeInformation.IsOSPlatform(MapOS[k.Platform]));
                return (ushort)keycode.Value;
            }
            catch
            {
                throw new PlatformNotSupportedException();
            }

        }
    }
}